using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<Uri> playlist = new List<Uri>(); // Плейлист
        private int currentTrackIndex = 0; // Текущий индекс трека в плейлисте
        private DispatcherTimer timer; // Таймер для обновления ползунка перемотки
        private bool isPlaying = false; // Флаг для отслеживания состояния воспроизведения

        public MainWindow()
        {
            InitializeComponent();
            playlistListBox.SelectionChanged += PlaylistListBox_SelectionChanged;
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновлять ползунок каждую секунду
            timer.Tick += Timer_Tick;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
            {
                mediaPlayer.Play();
                isPlaying = true;
            }
            else
            {
                mediaPlayer.Pause();
                isPlaying = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                seekSlider.Value = mediaPlayer.Position.TotalSeconds; // Обновить ползунок перемотки
                currentTimeTextBlock.Text = mediaPlayer.Position.ToString(@"hh\:mm\:ss"); // Обновить текущее время
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            isPlaying = false;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            isPlaying = false;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PlayNextTrack();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            PlayPreviousTrack();
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.Volume = volumeSlider.Value / volumeSlider.Maximum;
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Media Files (*.mp3;*.mp4;*.wav)|*.mp3;*.mp4;*.wav|All files (*.*)|*.*";
            openFileDialog.Multiselect = true; // Разрешаем выбор нескольких файлов

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    AddTrackToPlaylist(new Uri(fileName)); // Добавляем Uri каждого выбранного файла в плейлист
                }

                // Если это первый трек в плейлисте, начнем его воспроизведение
                if (playlist.Count == 1)
                {
                    mediaPlayer.Source = playlist[0];
                    mediaPlayer.Play();
                    isPlaying = true;
                }
            }
        }

        private void AddTrackToPlaylist(Uri trackUri)
        {
            playlist.Add(trackUri);
            UpdatePlaylistListBox();
        }

        private void UpdatePlaylistListBox()
        {
            playlistListBox.Items.Clear();
            foreach (Uri trackUri in playlist)
            {
                playlistListBox.Items.Add(System.IO.Path.GetFileName(trackUri.LocalPath));
            }
        }

        private void PlayNextTrack()
        {
            if (playlist.Count > 0)
            {
                currentTrackIndex++;
                if (currentTrackIndex >= playlist.Count)
                {
                    currentTrackIndex = 0;
                }
                mediaPlayer.Source = playlist[currentTrackIndex];
            }
        }

        private void PlayPreviousTrack()
        {
            if (playlist.Count > 0)
            {
                currentTrackIndex--;
                if (currentTrackIndex < 0)
                {
                    currentTrackIndex = playlist.Count - 1;
                }
                mediaPlayer.Source = playlist[currentTrackIndex];
            }
        }

        private void SeekSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan newPosition = TimeSpan.FromSeconds(seekSlider.Value);
                mediaPlayer.Position = newPosition;
            }
        }

        private void TogglePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            // Отобразить или скрыть плейлист
            if (playlistPopup.IsOpen)
            {
                playlistPopup.IsOpen = false;
            }
            else
            {
                playlistPopup.IsOpen = true;
                UpdatePlaylistListBox();
            }
        }

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                seekSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                seekSlider.Value = 0;
                totalTimeTextBlock.Text = mediaPlayer.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"); // Обновить общее время
                timer.Start(); // Запустить таймер при открытии медиафайла
            }
        }

        private void ShowUserGuide(object sender, RoutedEventArgs e)
        {
            // Открываем новое окно с руководством пользователя
            UserGuideWindow userGuideWindow = new UserGuideWindow();
            userGuideWindow.ShowDialog(); // Показываем окно как диалоговое
        }


        private void PlaylistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (playlistListBox.SelectedIndex != -1)
            {
                currentTrackIndex = playlistListBox.SelectedIndex;
                mediaPlayer.Source = playlist[currentTrackIndex];
            }
        }
    }
}
