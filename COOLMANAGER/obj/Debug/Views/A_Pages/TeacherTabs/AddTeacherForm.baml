   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:COOLMANAGER.Views.A_Pages.TeacherTabs%COOLMANAGER.Views.A_Pages.TeacherTabs  5   	   :    4COOLMANAGER.Views.A_Pages.TeacherTabs.AddTeacherForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:COOLMANAGER.Views.A_Pages.TeacherTabs     5   	     � Title$  AddTeacherForm��5   	   $��521.677��5	   	   $��547.962��5
   	   $��16(�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         	ItemsSpan �� Property �� Value��%H   &	        �� 5   
   .�5      ��  � ��$ 10q�6/   5      5      .��5   
   � $��30q�6   $��1��6   $��3��6+    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $��* �6    .+�5'   
   �� $��2��6   .+�5(      �� -   5        	 ��Name$	 	MainLabel��5)      $7��1Регистрация преподавателя��5(      $��30(�5*      $��Segoe UI Semibold)�5+      $��0��5,      $��0��5-      �� 5.      -   5        $	 WarningLabel��5/      $G��A*заполните все поля для регистрации��5.      
��� ���$��0��51      $��1��52      $
��Wrap=�53      $��Bottom=�54      55      �� 5:      $��1��6   #��[  6&   .+�5;      �� $��Имя��6   �� 5<      -   5        
 ��Name$
 NameTextBlock��5<      $��Введите имя��5=      5?      5A      �� 5F      $��1��6   $��1��6&   #��[  66   .+�5G      �� $��Фамилия��6   �� 5H      -   5        $
 SurnameTextBlock��5H      $#��Введите фамилию��5I      5K      5M      �� 5Q      $��2��6   $��0��6&   #��[  66   .+�5R      �� $.��(Отчество (при наличии)��6   �� 5S      -   5        $
 LastnameTextBlock��5S      $%��Введите отчество��5T      5U   <   5W      �� 5[      $��3��6   #��[  6&   .+�5\      �� $��
Логин��6   �� 5]      -   5        $
 LoginTextBlock��5]      $��Введите логин��5^      5_   9   5a      �� 5e      $��4��6   #��[  6&   .+�5f      �� $��Пароль��6   G� 5g      -   5         G�Name$ PasswordTextBlock��5g       G� Password$! Введите пароль��5h      5j      5k      �� 5m      $��4��6   $��1��6&   #��[  66   .+�5n      �� $%��Повторите пароль��6   G� 5o      -   5        $ RepeatPaswordTextBlock��5o      $% Повторите пароль��5p      5r      5s      �� 5v      $��5��6   $��0��6&   $��2��5w      #��[  5x      .+�5y      �� $%��Выберите предмет��6   �� 5z      -	   5         ��Name$ 	SubjectTB��5z      
������ $��0q�5|      $��0 5 0 10q�5}      $	��240��5~      $
��Left=�5      5�      5�      �� 5�   
    �� Orientation$ 
Horizontal=�6   $��6��5�      $��2��5�      $��Right=�5�      .+�5�      �� -
   5         ��Name$ CancelB��5�      $��Отменить��5�      $	��120��5�      $��30��5�      5�      �� 5�      -   5        $ RegisterButton��5�      $��Добавить��5�      $	��120��5�      $��30��5�      $��10 0 0 0q�5�      5�      5�      5�      5�      