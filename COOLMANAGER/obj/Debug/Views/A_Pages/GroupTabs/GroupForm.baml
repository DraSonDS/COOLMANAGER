   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:COOLMANAGER.ViewsCOOLMANAGER.Views  5      !    COOLMANAGER.Views.GroupForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:COOLMANAGER.Views     5      ���#2F3E46���#CAD2C5.��5      �   � RowDefinitions  5   
   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��70 �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   .+�5      �� $��Группы��6   $��42(�5      $
��10 0q�5      5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ AddGroupButton��5      $��Добавить��5         addB#��[  5      5      5      �� 5   
   $��2��6   $
��10 0q�6"   .+�5!      �� $��Фильтр��6   $��20(�6'   �� 5"       �� Orientation$ 
Horizontal=�6   $��40��5#      .+�5$      �� -   5         ��Name$ GroupSearchNameTextBox��5$      $��Наименование��5%        SearchTB#��[ 5&      5)      5*      5+      � 5,   
   $��3��6     5-      �� 5.      �� 5/      $��2* �6    .+�51      &   System.Windows.Controls.DataGrid  -   5          Name$ GroupDataGrid��51      $��2��6.      Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Группа��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *
group_name+  54      $ Дисциплина��6)   $ * 6=    6H   �� *name_subject+  55      $  Преподаватель��6)   $ * 6@    6K   �� *teachers_fullname+  56      $ Тип��6)    67   �� *type+4  .System.Windows.Controls.DataGridTemplateColumn  57      $  ��6-   	   MinWidth$	 50Q�67   
   CellTemplate
 58      �� 59      .R�5:   "   �� $��50��6-   .+�5;   &   ��   ButtonBorder#��[ 6-   ._�5<   *   �� $��EditB��61   -   5         	 GridB#��[ 5=   1    � ToolTip$  Редактировать��5?   1    ^� InitialShowDelay$ 1��5@   1   .��5A   .   �� $ ��/Images/Icons/editIcon.png��64   $��4q�6X   5B   +   5C   '   �� 5D   &   #��[ 6-   ._�5E   *   �� $��DeleteB��61   -   5        #��[ 5F   1   ���#f2674b$ Удалить��5I   1   $ 1��5J   1   .��5K   .   �� $"��/Images/Icons/deleteIcon.png��64   $��4q�6[   5L   +   5M   '   5N   #   5O      5Q         	CellStyle 5S      �� 5T       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5U      -   5        �� 5W       �� Property � �� �� Value$ 4 5 4 5q�64   �� 5X       � ��
 ���� 6<   �� 5Y       � ��$	 Top=�6B   �� 5Z       � ��$
 Left=�6D   �� 5[       � ��$
 auto��67   �� 5\       � ��$
 auto��66   �� 5]       � ��
 �   �6;   �� 5^       � ��$ 16(�69    �� Triggers 5_      P� 5`   "    P� Property �@ 
IsSelected P� Value . . �5a   &   ��  � �� 6C   Z� �� 5b   &    � ��
 �   �6C   �� 5c   &    � ��
 ���� 6D   5d   #   5f      5h      5i      5j      5k      