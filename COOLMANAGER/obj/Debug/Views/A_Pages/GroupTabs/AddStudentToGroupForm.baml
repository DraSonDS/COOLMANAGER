   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:COOLMANAGER.Views.A_Pages.GroupTabs#COOLMANAGER.Views.A_Pages.GroupTabs  5   	   ?    9COOLMANAGER.Views.A_Pages.GroupTabs.AddStudentToGroupForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:COOLMANAGER.Views.A_Pages.GroupTabs     5   	   $��418.915��5   	     � 
ResizeMode$  NoResize=�6    � WindowStyle$
 None=�5	   	   $��357.667��5
   	   $��16(�5   	    � WindowStartupLocation$ CenterScreen=�6    � 	Resources 5       �� 
TargetType �� Property �� Value 	  Arrow��%9  '��       &	  �     �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$	 170��6&   �� 5       � ��$	 250��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 30��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 5q�6'   5      5      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5      �� $;��5Добавление учеников в группу��6   5      �� 5    
   
���   �$��2��6$   $��Bottom=�6/   � 5#   
    � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5(      �� $)��#Ученики не в группе��6   $��0��5)      $��Center=�5*      �� 5+      $$��Ученики в группе��6   $��1��5,      $��Center=�5-      5.      �� 50   
   $ 
Horizontal=�6   $��Center=�51      .+�52      �� -   5        $��LeftListBox��53      �� 54      $��Center=�6   .+�55      �� -   5        	 ��Name$	 b1��57      #��[  55      $	��》��56      57   %   �� 58      -   5        $	 b2��5:      #��[  58      $	��《��59      5:   %   5;      �� 5<      -   5        $��RightListBox��5=      5?      �� 5F   
   $ 
Horizontal=�6   $��Right=�5G      .+�5H      �� -   5        $	 CloseB��5H      $��Отменить��5I      $	��100��5J      $��10q�5K      5L      �� 5M      -   5        $	 SRegistrateB��5M      $��Добавить��5N      $	��100��5O      $��10q�5P      6!   5R      5S      5T      