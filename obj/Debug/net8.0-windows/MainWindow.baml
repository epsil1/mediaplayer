   M S B A M L   `   `   `  ����  WpfApp2    WpfApp2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Media Player Example��5   	   $	��720��6&   $
��1280��63    � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   � .+�5
      �� -   5        $
��Left=�5
   +   $	��Top=�6F   $��10q�6^   .��5      �� $	��❓��6   $��34��6%   $��34��60   5      r� 5      -   5         r�Name$ mediaPlayer��5      $��Center=�60   $��Center=�6M    r� LoadedBehavior$ Manual=�6h    r� UnloadedBehavior$ Manual=�6�   �� 5       �� Orientation$ Vertical=�6   $��Center=�60   $��Bottom=�6M   $��20q�6h   .+�5      �� $ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5         ��Name$ currentTimeTextBlock��5       $
��Left=�6>   $��Center=�6Y   $��5q�6t   
�������6   �� 5      -   5         ��Name$ 
seekSlider��5      $	��300��61   6=   �� 5      -   5        $ totalTimeTextBlock��5       $��Right=�6<   $��Center=�6X   $��5q�6s   
�������6~   5      �� 5      $ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�5      �� -   5         ��Name$ openFileButton��5      $	��⏏��65   ���#3498DB
�������$��5q�6�   �� 5      -   5        $ previousButton��5      $	��⏪��65   ���#9B59B6
�������$��5q�6�   �� 5      -   5        $ 
playButton��5      $	��▶��61   ���#27AE60
�������$��5q�6~   �� 5      -	   5        $ 
nextButton��5      $	��⏩��61   ���#9B59B6
�������$��5q�6~   �� 5       -
   5        $ togglePlaylistButton��5       $
��🎵��6;   ���#E74C3C
�������$��5q�6�   5!      �� 5$      $ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�5%      �� $��Громкость:��6    $��Center=�62   $��5q�6M   
���   �6X   �� 5&      -   5        $ volumeSlider��5&      $	��100��63   	 � Maximum$	 1Q�6h   
 � Minimum$
 0Q�6t    � Value$	 0.5Q�6�   $��5q�6�   5'      � 5*      -   5         �Name$ playlistPopup��5*      $��Bottom=�6/    � 	StaysOpen$ False��6   $��False��6�    � PlacementTarget 6B   ��  �� ElementName$ togglePlaylistButton��.��5+      �� -   5         ��Name$ playlistListBox��5+      $
��Left=�67   $	��Top=�6R   $	��200��6j   $	��300��6v   5,      5-      5.      5/      50      