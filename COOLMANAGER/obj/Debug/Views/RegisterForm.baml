   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:COOLMANAGER.ViewsCOOLMANAGER.Views  5   	   $    COOLMANAGER.Views.RegisterForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:COOLMANAGER.Views     5   	     � Title$  RegisterForm��5   	   $	��800��5	   	   $
��1200��6    � WindowStartupLocation$ CenterScreen=�5
   	   $	��800��5   	   $
��1100��5   	    � 
ResizeMode$ NoResize=�5   	   $��24(�5   	    � WindowStyle$
 None=�6    � 	Resources 5         	ItemsSpan �� Property �� Value��%H   &	        �� 5   
   .�5      ��  � ��$ 10q�6/   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $+��%/Images/nice-minimalist-workplace.jpg��6   � 5(   
   $��30q�6   $��1��6   $��3��6+    5)      �� 5*      $��* �6#   �� 5+      $��* �6#    � RowDefinitions 5.      �� 5/      $
��auto �6    �� 50      $
��auto �6    �� 51      $
��auto �6    �� 52      $
��auto �6    �� 53      $
��auto �6    �� 54      $
��auto �6    �� 55      $
��auto �6    �� 56      $��* �6    .+�5:      �� $��Регистрация��6   $��42(�5;      $��Segoe UI Semibold)�5<      $��0��5=      $��0��6)   �� 5>      -   5        	 ��Name$	 WarningLabel��5?      $��WarningLabel��5>      ���#eba926$��0��5A      $��1��6%   $
��Wrap=�5B      �� 5F      $��1��6   #��[  6&   .+�5G      �� $��Имя��6   �� 5H      -   5        
 ��Name$
 NameTextBlock��5H      $$��Введите ваше имя��5I      
������ $��0q�5K       J� Opacity$	 0.5Q�5L      $��30��5M      $
��Left=�5N      $��0 5 0 10q�5O      5Q      �� 5R      $��2��6   
���   �$	 0.5Q�5T      5U      �� 5Z      $��1��6   $��1��6&   #��[  66   .+�5[      �� $��Фамилия��6   �� 5\      -   5        $
 SurnameTextBlock��5\      $,��&Введите вашу фамилию��5]      
������ $��0q�5_      $	 0.5Q�5`      $��30��5a      $
��Left=�5b      $��0 5 0 10q�5c      6M   �� 5d      $��2��6   
���   �$	 0.5Q�5f      5g      �� 5k      $��2��6   $��0��6&   #��[  66   .+�5l      �� $.��(Отчество (при наличии)��6   �� 5m      -   5        $
 LastnameTextBlock��5m      $.��(Введите ваше отчество��5n      
������ $��0q�5p      $	 0.5Q�5q      $��30��5r      $
��Left=�5s      $��0 5 0 10q�5t      6N   �� 5u      $��2��6   
���   �$	 0.5Q�5w      5x      �� 5|      $��3��6   #��[  6&   .+�5}      �� $��
Логин��6   �� 5~      -   5        $
 LoginTextBlock��5~      $&�� Введите ваш логин��5      
������ $��0q�5�      $	 0.5Q�5�      $��30��5�      $
��Left=�5�      $��0 5 0 10q�5�      6K   �� 5�      $��2��6   
���   �$	 0.5Q�5�      5�      �� 5�      $��4��6   #��[  6&   .+�5�      �� $��Пароль��6   G� 5�      -   5         G�Name$ PasswordTextBlock��5�       G� Password$( "Введите ваш пароль��5�      
������ $��0q�5�      $	 0.5Q�5�      $��30��5�      $
��Left=�5�      $��0 5 0 10q�5�      6N   �� 5�      $��2��6   
���   �$	 0.5Q�5�      5�      �� 5�      $��4��6   $��1��6&   #��[  66   .+�5�      �� $%��Повторите пароль��6   G� 5�      -   5        $ RepeatPaswordTextBlock��5�      $% Повторите пароль��5�      
������ $��0q�5�      $	 0.5Q�5�      $��30��5�      $
��Left=�5�      $��0 5 0 10q�5�      6S   �� 5�      $��2��6   
���   �$	 0.5Q�5�      5�      �� 5�      $��5��6   #��[  6&   .+�5�      �� $��Статус��6   �� 5�      -   5         ��Name$ PostCB��5�      
������ $��0q�5�      $��0 5 0 10q�5�      .@�5�      ��  �� 
IsSelected . .��5�      �� $*��$Выберите ваш статус��6$   5�      �� 5�      .��5�      �� $ ��Администратор��6$   5�      �� 5�      .��5�      �� $ ��Преподаватель��6$   5�      �� 5�      .��5�      �� $��Ученик��6$   5�      5�      5�      �� 5�      -	   5         ��Name$ RegisterButton��5�      $*��$Зарегистрироваться��5�      $	��300��5�      $��50��5�      
������ 
�������$��3q�5�      $��6��5�      $��2��5�      �� 5�      -
   5        $ ReturnToLoginButton��5�      
������ $��0q�5�      $��7��5�      $��2��5�      $��Bottom=�5�      .��5�      �� .+�5�      �� $"��Войти в аккаунт��6    $��Light"�5�      �� 5�      $��2��6   
���   �$	 0.5Q�5�      5�      5�      5�      5�      5�      