   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:COOLMANAGER.Views.A_Pages.FinanceTabs%COOLMANAGER.Views.A_Pages.FinanceTabs  5   	   4    .COOLMANAGER.Views.A_Pages.FinanceTabs.AddPurse   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:COOLMANAGER.Views.A_Pages.FinanceTabs     5   	     � Title$  AddPurse��5   	   $��236.912��5	   	   $��469.856��5
   	   $��16(�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��5q�6.   .+�5      �� -   5         ��Name$ 	MainLabel��5   2   $)��#Добавление платежа��6   62   �� 5      -   5        $ WarningLabel��5      $��10 0 0 0q�6.   
��� ���$H��B*заполните все поля для ввода данных��5      5      �� 5   
   
���   �$��2��6$   $��Bottom=�6/   � 5   
   $��	10 20 0 0q�6    � ColumnDefinitions 5      �� 5      $	��130 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5       $��40 �6    �� 5!      $��40 �6    �� 5"      $��40 �6    .+�5%      �� $��Ученик��6   $��Center=�5&       �� 5'      -   5         ��Name$ 	studentCB��5,      $	��200��5'      $��20 0 0 0q�5(      $��1��5)      $��Center=�5*      $
��Left=�5+      	 �� SelectedValuePath$	 
id_student��5.      ��50      �� 51      .R�52      �� $ 
Horizontal=�6%   .+�53      �� ��6(   �� *	surname+�� 54      $��5 0 0 0q�55   (   ��54   (   �� *name+55   (   �� 56      $ 	idStudent��57   (   $��5 0 0 0q�58   (   $y�Hidden=�69   ��56   (   �� *
id_student+58   9   59      5:      5<      �� 5>      $��Группа��6   $��1��5?      $��Center=�5@      �� 5A      -   5        $ groupCB��5G      $	��200��5A      $��20 0 0 0q�5B      $��1��5C      $��1��5D      $��Center=�5E      $
��Left=�5F      5I      �� 5K      $��Сумма (руб.)��6   $��2��6,   $��Center=�5L      �� 5M      -   5        
 ��Name$

 summ��5M      $��2��5N      $��1��5O      $	��200��5P      $��Center=�5Q      $
��Left=�5R       �� 	MaxLength$ 10��5S      $��20 0 0 0q�5T      5U      5Z      �� 5]   
   $ 
Horizontal=�6   $��Right=�6.   .+�5^      �� -   5         ��Name$ CloseB��5^      $��Отменить��5_      $	��100��5`      $��10q�5a      6!   �� 5b      -   5        $ SRegistrateB��5b      $��Добавить��5c      $	��100��5d      $��10q�5e      5f      5g      5h      5i      