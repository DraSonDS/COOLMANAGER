   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:COOLMANAGERCOOLMANAGER  5   	   g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks 61       COOLMANAGER.LoginForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:COOLMANAGER     5   	   e	iconPacksOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material     61   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��380��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         	RoundedBS �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Padding��%�  &	        �� 5   
   " ��6"   .�5      ��  � ��$ 40��6'   �� 5       � ��$	 100��6&   �� 5       � ��
 �����6+   �� 5       � ��$ 	Helvetica)�6+   �� 5       � ��$ Light"�6+   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 15��6!   ���#2F3E46$��1q�5!   !   $ 2q�5"   !   ._�5#      �� $��Center=�6/   $��Center=�5$   /   5%      5&      5(      5)      5+      .��5,      � .+�5-   
   �  � RowDefinitions 5/      �� 50      �� 51      .+�55      �� $
 10��6   $��2��6'   ��56      �� 57      .��58      �  � Color$ #354F52��6'    � Offset$	 0.0Q�67   � 59      $ #52796F��6'   $ 1Q�67   5:      5<      �� 5?      -   5         ��Name$ CloseB��5F      $��30��5?      $��30��5@      $	��Top=�5A      $��Right=�5B      $��5q�5C      
������ $��0q�5E      .��5G      �� $$��/Images/menuBtns/MCloseBtn.png��6   5H      �� 5I      $��Center=�6   .+�5J      �� $$��/Images/Logotip_CoolSchool.png��6   $	��100��6@   �� 5K      $��COOLMANAGER��6   $��Light"�5L      $��	helvetica)�5M      $��22(�5N      
�������$��Center=�5P      5Q      �� 5U      $��1��6   .+�5V      ��  �� Orientation$ 
Horizontal=�6   .+�5W      �� -   5         ��Name$ LoginTextBox��5W      $��	Helvetica)�5X      $��Light"�5Y      $��
Логин��5Z      $��20(�5[      $��Center=�5\      
�������
������ $��0q�5_      $	��235��5`      $
��Left=�5a       J� Opacity$	 0.5Q�5b      $��25��5c      $��64 0 0 0q�5d      5g      .  (MahApps.Metro.IconPacks.PackIconMaterial  5h         Kind$ Account=�61   $��Center=�5i   "   $��Center=�5j   "   
�������5k   -   5l      �� 5m      $	��250��6   $��2��5n      
�������$	 0.5Q�5p      �� 5s      $ 
Horizontal=�6   $��0 20 0 0q�66   .+�5t      G� -   5         G�Name$ PasswordPassBox��5t   "   $��	Helvetica)�5u   "   $��Light"�5v   "    G� Password$ Пароль��5w   "   $��20(�5x   "   $��Center=�5y   "   
�������
������ $��0q�5|   "   $	��235��5}   "   $
��Left=�5~   "   $	 0.5Q�5   "   $��25��5�   "   $��64 0 0 0q�5�   "   5�   "     5�      $ FormTextboxPassword=�61   $��Center=�5�   "   $��Center=�5�   "   
�������5�   "   5�      �� 5�      $	��250��6   $��2��5�      
�������$	 0.5Q�5�      �� 5�      $ 
Horizontal=�6   $��0 50 0 0q�66   $��Center=�5�      .+�5�      �� -   5        $ LoginButton��5�      $��
ВОЙТИ��5�      $��0 0 15 0q�5�      #��[  5�      5�      �� 5�      -   5        $ RegisterButton��5�      #��[  5�      $
��15 0q�5�      $��РЕГИСТРАЦИЯ��5�      5�      5�      5�      5�      5�      5�      