   M S B A M L   `   `   `  ����>  :PDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PDD.pages	PDD.pages  5          PDD.pages.Statistics   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:PDD.pages     5        N� Title$  
Statistics��5	       � 	Resources 5
         ProgressBar.Progress �� Color  ProgressBar.Background  ProgressBar.Border  ProgressBarStyle1 �� 
TargetType �� Property �� Value �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value �� CornerRadius ��Name �� RadiusX �� RadiusY J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle��%q  &	        &	 #     &	 F     &	 i     7   7  7  �� 5   
   $ 	#FF06B025��67   �� 5   
   $ 	#FFE6E6E6��69   �� 5   
   $ 	#FFBCBCBC��65   �� 5   
   " �6*   .�5      ��  � ��8   6+   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      " �6&   .R�5      � $ TemplateRoot��6    5        5   "   CommonStates��.	 5   &     Determinate��62     5   &   Indeterminate��.
 5   *   �� $ Forever��65   .��5   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $ 	Animation��6�   .\�5   2     $ 0��6G   $
 0.25Q�6S     5   2   $ 0:0:1��6G   $
 0.25Q�6W     5   2   $ 0:0:2��6G   $
 0.25Q�6W   5    /   *� 5!   .   $' !(UIElement.RenderTransformOrigin)�6K   $ 	Animation��6�   .'�5"   2     $ 0��6F   $ -0.5,0.5&�6R     5#   2   $ 0:0:1��6F   $ 0.5,0.5&�6V     5$   2   $ 0:0:2��6F   $ 1.5,0.5&�6V   5%   /   5&   +   5'   '   5(   #   .+�5*      �� #��z��6%   #��z��6Q   #��z��6�   $ 5��6�   �� 5+      $ 
PART_Track��6(   � 5,      $ PART_Indicator��6#   }�. $
��Left=�6O   .+�5-   "   �� $ 	Indicator��6,   #��z��6?   $ 5��6c   $ 5��6o   �� 5.   "   $ 	Animation��6,   #��z��6?   $ 0.5,0.5&�6c   $ 5��6�   $ 5��6�   z�5/   &   V� 50   *   .~�51   .   �� �� 52   .   �� 53   .   T� 54   .   55   +   57   #   58      59       5:      P� 5;       �@�Orientation$ Vertical=�6=   . �5<   "   �� $ TemplateRoot��6D    �@�LayoutTransform 5=   &   �� 5>   *   $	 -90Q�6:   5@   #   5A      P� 5B       �@�IsIndeterminate . . �5C   "   �� $ 	Indicator��6?    � y�$ 	Collapsed=�6V   5D      5F      5H      5I      5J      .��5L      � ���	#FF212121 � ColumnDefinitions 5M   
   �� 5N      �� 5O      $	��800 �6   �� 5P      .+�5S   
   �� $��1��6   $��Center=�6%   $��Center=�5T      .+�5U      �� $��1��6   $��Center=�5V      .+�5W      �� -   5         ��Name$ Label4��5W      $��1��5X      
�������$��Center=�5Z      $��24(�5[      �� 5\      -   5        $ Label2��5\      $��1��5]      
�������$��Center=�5_      $��24(�5`      5a      �� 5c      $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�5d      $	��Top=�5e      .+�5h      �� -   5        $ label6��5h      $��0��6(   
�������$��24(�5i      � 5j      -   5         �Name$ ProgressBar1��5j   @     � Value$  50Q�6   ���	#FF94D5EE$��30��6V   $	��300��6b   #���  6n   �� 5l      $��40��6   
�������$��24(�5m      5n      5p      �� 5q   
   -   5        ! ��Name$! backButton1��5r      $��2��5q      $	��100��5s      $��40��6!   $��
Назад��5t      $	��Top=�5v      $��0,50,0,0q�5w      5z      5{      