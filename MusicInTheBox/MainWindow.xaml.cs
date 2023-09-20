using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MusicInTheBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = "MusicBox";
        private MediaPlayer mediaPlayer = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void play(object sender, RoutedEventArgs e)
        {
            if (path == "MusicBox") { return; }
            mediaPlayer.Play();
            status.Text = "playing";
        }

        private void stop(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Pause();
            mediaPlayer.Close();
            desc.Text = "drop file here";
            path = "MusicBox";
            status.Text = "stoped";
        }

        private void load(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = files[0];
            if (file[file.Length - 1] != '3') { return; }
            path = file;
            mediaPlayer.Open(new Uri(path));
            desc.Text = path;
        }

        private void pause(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            status.Text = "paused";
        }
    }
}
