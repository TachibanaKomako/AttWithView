using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttWithView.MVVMs.Messages
{
    public class ShowWindowMessage : IMessage
    {
        public ShowWindowMessage(Window window)
        {
            Window = window;
        }
        public Window Window { get; private set; }

        public void DefaultAccept()
        {
            Window? w = Application.Current.Windows.OfType<Window>().FirstOrDefault();
            
            void W_Closed(object? sender, EventArgs e)
            {
                w.Visibility = Visibility.Visible;
                Window.Closed -= W_Closed;
            }
            if (w != null)
            {
                w.Visibility = Visibility.Collapsed;
                Window.Closed += W_Closed;
                Window.Show();
            }
        }

        
    }
}
