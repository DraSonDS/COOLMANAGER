   M S B A M L   `   `   `  ����F  BCOOLMANAGER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:COOLMANAGERCOOLMANAGER  5   	   ?$clr-namespace:COOLMANAGER.ViewModelsCOOLMANAGER.ViewModels  5   	   5clr-namespace:COOLMANAGER.ViewsCOOLMANAGER.Views  5   	   S.clr-namespace:COOLMANAGER.Views.GroupEditForms COOLMANAGER.Views.GroupEditForms  5	   	       COOLMANAGER.MainForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:COOLMANAGER     5   	   ;
viewmodels$clr-namespace:COOLMANAGER.ViewModels     5   	   1viewsclr-namespace:COOLMANAGER.Views     5   	   IviewsGroupEdit.clr-namespace:COOLMANAGER.Views.GroupEditForms     5	   	     � Title$  MainForm��5   	   $	��680��5   	   $
��1200��5   	   $	��600��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	    � 	Resources 5       	  MenuB �� 
TargetType �� Property �� Value  MenuButtonImage  
LeftPanelB	 �� Triggers  LeftPanelB_SP  LeftPanelB_Image  LeftPanelB_TB
 �� Binding �� ElementName �� Path �� Value N� EnterActions �� TargetProperty g� 	BeginTime W� From	 W� To g� Duration W� EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  ExpanderStyle �� 
TargetType �� Padding  ExpanderHeaderFocusVisual J� SnapsToDevicePixels �� StrokeDashArray  ExpanderDownHeaderStyle 	 ModernExpander d�Name � FocusVisualStyle d� 	IsChecked �� Mode �� RelativeSource �Name  �� Stretch! �� Triggers" P� Property# P� Value$ �� 
TargetName��%0  &	        &	 �     &	 !    &	 �    &	 �    &	 A    &	 �    &	 f    &	 )    &		  	    7  7  �� 5   
   " ��6   .�5      ��  � ��$ 40��6&   �� 5       � ��$ 40��6'   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6(   .�5      ��  � ��$ 20��6&   �� 5        � ��$ 20��6'   5!      �� 5#   
   " ��6#   .�5$      -   5        �� 5%       � ��$ 0q�60   �� 5&       � ��
 ���� 6+   	 5'      5*      �� 5+   
   " ��6&   .�5,      ��  � ��$ Center=�62   �� 5-       � ��$
 Left=�64   �� 5.       � ��$
  180��6&   �� 5/       �@��Orientation$ 
Horizontal=�6,   �� 50       � ��$
 Left=�64   �� 51       � ��$ 5 0 0 0q�6'   52      �� 53   
   " ��6)   .�54      ��  � ��$ 30��6&   �� 55       � ��$ Center=�62   56      �� 57   
   " ��6&   .�58      ��  � ��$ 5 0 0 0q�6'   �� 59       � ��$ Center=�62   �� 5:       � �� �#CAD2C56+   �� 5;       � ��$ 14(�6)   	 5<      �� 5=      
 6   �� $ Toggle_Button��$ 	IsChecked� True6`    5>      �� 5?      .��5@      �� .��5A   "   W� $ Opacity�62   $ 0:0:0X�5B   2   $ 1X�5C   2   $ 0X�6;   $ 0:0:0.1D�5D   2    5E   &     5F   *   $ 	EaseInOut=�64   5H   #   5I      5J      5L      �� 5M      
 6   �� $ Toggle_Button��$ 	IsChecked�	 False6`    5N      �� 5O      .��5P      �� .��5Q   "   W� $ Opacity�62   $ 0:0:0X�5R   .   $ 0X�5S   .   $ 1X�67   $ 0:0:0.4D�5T   .    5U   &     5V   *   $ 	EaseInOut=�64   5X   #   5Y      5Z      5\      5^      �� 5_   
   " d�6&   .�5`      ��  � �� 5a      �� 5b      " d�6&   .R�5c      �� # z��6!   
������ ._�5d      �� $
��Left=�6/   ��. $��Center=�6e   5e      5f      5h      5i      �� 5k   
   .�5l      ��  � �� 5m      �� 5n      .R�5o      �� ._�5p      �� $��0q�6(    . 
���   �$��1��6]   $	 1 2R�6q   5q      5r      5t      5u      �� 5v   
   " d�60   .�5w      ��  � �� 5x      �� 5y      " d�6&   .R�5z      �� 
������ ._�5{      �� $
��Left=�6/   ��.  . $��Center=�6�   5|      5}      5      5�      �� 5�   
   " 9�6'   .�5�      ��  � ��# � ��6+   �� 5�       � ��
 ���� 6+   �� 5�       � ��$ Stretch=�6;   �� 5�       � ��$ Stretch=�69   �� 5�       � ��
 ���� 6,   �� 5�       � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " 9�6&   .R�5�      �� #��z��6!   #��z��6M   #��z��6�    . ._�5�      ]� .+�5�   "   d� $ 
HeaderSite��6/   #��z��6C   #��z��6v   #��z��6�   $	��Top=�6�   #��z��6�   #��z��6  8   #��z��6�  #��z��6�  #��z��6�  #��z��6�  $��0q�6�  $��0��6�  $��0��6�  8�� #��z��6�   6'  �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+6�  � 5�   "   $ 
ExpandSite��6<   ���#52796F$��Bottom=�6P   #��z��6h   #��z��6�   $y�	Collapsed=�6�   #��z��6�   .+�5�   &   �� .+�5�   *   F� "���� -1    р��    ����� 	$��0��6M   ���#2F3E46$
  None=�6p   5�   '   �� 5�   &   |�.  67   5�   #   5�      5�      ! 5�      P� 5�      " �@9�
IsExpanded# . . �5�   "   �� $$ 
ExpandSite��6?    � y�$ Visible=�6W   5�      P� 5�      " � {�# .  . �5�   "   �� # � ��6?    � ��5�      5�      5�      5�      5�      .��5�      ]� ���#2F3E46.+�5�   
   ]� $	��Top=�6   ���#425057.+�5�      �� % �� Orientation$% 
Horizontal=�6   $��40��5�      $
��Left=�5�      .+�5�      �� -   5        & ��Name$& MainTextStackPanel��5�      $	��180��5�      $% 
Horizontal=�5�      .+�5�      �� -   5        ' ��Name$' MainTextBlock��5�       $��COOLMANAGER��5�       $��5 0 0 0q�5�       $��Center=�5�       $��22(�6;   ���#CAD2C55�       5�      d� 5�      -   5        $ Toggle_Button��5�      $��40��5�      $��40��5�      $	��Top=�5�      $��0q�5�      ��5�      �� 5�      ( �� ImageSource$)( #/Images/Icons/toggleButtonIconW.png��6%   ) j� Stretch$) UniformToFill=�5�   %   * � Triggers* 5�      :� 5�      + :� RoutedEvent$+ ToggleButton.Checked��6'   .[�5�      �� .��5�   "   �� -   5        , ��Name$, HideStackPanel��5�   -   .��5�   &   W� - �� 
TargetName$- Navigation_panel��66   $ Width�5�   6   $ 0:0:0X�5�   6   $	 180X�5�   6   $ 35X�6A   $ 0:0:0.2D�5�   6    5�   *     5�   .   $ 	EaseInOut=�68   5�   '   W� 5�   &   $- MainTextStackPanel��66   $ Width�5�   6   $ 0:0:0X�5�   6   $	 180X�5�   6   $ 35X�6A   $ 0:0:0.2D�5�   6    5�   *     5�   .   $ 	EaseInOut=�68   5�   '   5�   #   5�      5�      :� 5�      $+ ToggleButton.Unchecked��6'   .[�5�      �� .��5�   "   �� -   5        $, ShowStackPanel��5�   -   .��5�   &   W� $- Navigation_panel��5�   1   $ Width�5�   1   $ 0:0:0X�5�   1   $ 35X�5�   1   $	 180X�6;   $ 0:0:0.3D�5�   1    5�   *     5�   .   $ 	EaseInOut=�68   5�   '   W� 5�   &   $- MainTextStackPanel��66   $ Width�5�   6   $ 0:0:0X�5�   6   $ 35X�5�   6   $	 180X�6@   $ 0:0:0.3D�5�   6    5�   *     5�   .   $ 	EaseInOut=�68   5�   '   5�   #   5�      5�      5�      5�      �� 5      -   5        . ��Name$. CloseB��5      $��Right=�5     $��Right=�5     #��[  5     .��5     �� $$��/Images/menuBtns/MCloseBtn.png��6   #��[ 5     5     �� 5
     -   5        $' 
UserNameTB��5
     $��Username��5     $��Right=�5     $��Right=�5     $��0 0 10 0q�5     $��Center=�5     ���#CAD2C5$��26(�5     / � ToolTip$&/  Выйти из аккаунта��5     0 ^� InitialShowDelay$0 1��5     5     5     �� 5  
   -	   5        $& Navigation_panel��5     $
��Left=�5     $	��180��5     ���#2F3E46$
��Left=�5     .+�5     �� #��[ 6   .��5      �� #��[ 6   .+�5!     �� $ ��/Images/Icons/lidIconW.png��6   #��[ 5"     �� 5#     $��Лиды��6    #��[ 5$      5%     5&     �� 5'     #��[ 6   .��5(     �� #��[ 6   .+�5)     �� $$��/Images/Icons/studentIconW.png��6   #��[ 6D   �� 5*     $��Студенты��6    #��[ 5+      5,     5-     �� 5.     #��[ 6   .��5/     �� #��[ 6   .+�50     �� $$��/Images/Icons/teacherIconW.png��6   #��[ 6D   �� 51     $ ��Преподаватели��6    #��[ 52      53     54     �� 55     #��[ 6   .��56     �� #��[ 6   .+�57     �� $"��/Images/Icons/GroupIconW.png��6   #��[ 6B   �� 58     $��Группы��6    #��[ 59      5:     5;     9� 5<     #��� 	 6   ��5=     �� 5>     #��[ 6!   .+�5?     �� $$��/Images/Icons/financeIconW.png��6    #��[ 6H   �� 5@     $��Финансы��6$   #��[ 64   5A     .��5C     �� .+�5D     �� #��[ 6   .��5E     �� #��[ 6%   $��30��6L   .+�5F     �� $*��$Поступления и счета��6(   #��[ 5G  (   $��13(�5H  (   5I     5J     �� 5K     #��[ 6   .��5L     �� #��[ 6%   $��30��6L   .+�5M     �� $��Должники��6(   #��[ 5N  (   5O     5P     5Q     5R     �� 5S     #��[ 6   .��5T     �� #��[ 6   .+�5U     �� $#��/Images/Icons/reportIconW.png��6   #��[ 5V     �� 5W     $��Статистика��6    #��[ 5X      5Y     5Z     5[     �� 5^  
   -
   5        1 ��Name$1 ContentPlace��5_     $��Right=�5^     $��5q�5`     5a     5c     