   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:COOLMANAGER.ViewsCOOLMANAGER.Views  5   	   ,    &COOLMANAGER.Views.ST_StudentMainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:COOLMANAGER.Views     5   	   -   5          � Title$  ST_StudentMainWindow��5   	   $	��650��5	   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�5
   	   ���#536066 � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	    � 	Resources 5       	  MenuB �� 
TargetType �� Property �� Value  MenuButtonImage��%5  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 40��6&   �� 5       � ��$ 40��6'   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6(   .�5      ��  � ��$ 20��6&   �� 5       � ��$ 20��6'   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5"   
   �� 
 �� Orientation$
 
Horizontal=�6   $��Right=�6.   .+�5$      �� -   5         ��Name$ NameTextBlock��5$      $��Пользователь��5%      $��Center=�5&      ���#CAD2C5$��26(�5(       � ToolTip$&  Выйти из аккаунта��5)       ^� InitialShowDelay$ 1��5*      $��0 0 10 0q�5+      5,      �� 5.      -   5         ��Name$ CloseB��5.      $��Right=�5/      $��Right=�50      #��[  51      .��53      �� $$��/Images/menuBtns/MCloseBtn.png��6   #��[ 54      56      57      �� 5:   
   -   5         ��Name$ ContentHolderFrame��5:      $��1��65   5;      5=      