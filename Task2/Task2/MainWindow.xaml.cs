using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public delegate void Test();
        private void Runner_Click(object sender, RoutedEventArgs e)
        {
            var sync_context = SynchronizationContext.Current;

            ThreadPool.QueueUserWorkItem(delegate
            {
                sync_context.Post(delegate
                {
                    Executor1();
                }, null);
            });

            ThreadPool.QueueUserWorkItem(delegate
            {
                sync_context.Post(delegate
                {
                    Executor2();
                }, null);
            });

            ThreadPool.QueueUserWorkItem(delegate
            {
                sync_context.Post(delegate
                {
                    Executor3();
                }, null);
            });

         }

        public async void Executor1()
        {
            var res1 = new Resourse1(resource1);          
            var res2 = new Resourse2(resource2);
            while (true)
            {
                await res1.Worked(5000, "Executor1");
                await res2.Worked(3000, "Executor1");
                await res1.Worked(1000, "Executor1");

            }
        }
        public async void Executor2()
        {
            var res1 = new Resourse1(resource1);
            var res2 = new Resourse2(resource2);

            while (true)
            {
                await res1.Worked(3000, "Executor2");
                await res2.Worked(3000, "Executor2");
                await res1.Worked(3000, "Executor2");
            }
        }
        public async void Executor3()
        {
            var res1 = new Resourse1(resource1);
            var res2 = new Resourse2(resource2);

            while (true)
            {
                await res1.Worked(1000, "Executor3");
                await res2.Worked(3000, "Executor3");
                await res1.Worked(5000, "Executor3");
            }
        }

        
    }

    public class Resourse1
    {
        TextBlock _resource;
        public Resourse1(TextBlock resource)
        {
            _resource = resource;
        }

        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public async Task Worked(int worktime, string executor)
        {
            await semaphore.WaitAsync();
            _resource.Text = $"Занят {executor} на {worktime} мс";
            await Task.Delay(worktime);
            semaphore.Release();
            _resource.Text = $"Свободен";
        }
    }

    public class Resourse2
    {
        TextBlock _resource;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public Resourse2(TextBlock resource)
        {
            _resource = resource;
        }

        public async Task Worked(int worktime, string executor)
        {
            await semaphore.WaitAsync();
            _resource.Text = $"Занят {executor} на {worktime} мс";
            await Task.Delay(worktime);
            semaphore.Release();
            _resource.Text = $"Свободен";
        }
    }

    public class Resourse3
    {
        TextBlock _resource;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public Resourse3(TextBlock resource)
        {
            _resource = resource;
        }

        public async Task Worked(int worktime, string executor)
        {
            await semaphore.WaitAsync();
            _resource.Text += $"Занят {executor} на {worktime} мс";
            await Task.Delay(worktime);
            semaphore.Release();
            _resource.Text = $"Свободен";
        }
    }

}
