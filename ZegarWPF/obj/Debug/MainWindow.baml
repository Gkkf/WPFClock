   M S B A M L   `   `   `  ����C  ?ZegarWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ZegarWPFZegarWPF  5   	       ZegarWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ZegarWPF     5   	     � Title$  
MainWindow��5   	   $	��603��6   $	��800��6)   $	��603��65   $	��800��6E   $	��603��6T   $	��800��6d    � WindowStartupLocation$ CenterScreen=�6s   .��5	      � .+�5
   
   � $��1��6   $��0,30,0,0q�6   .+�5      �� -   5         ��Name$ clock��5   c   $	��300��6   $	��300��6!   $	��Top=�6.   $��Center=�6F   .+�5      A� 
�������
�������$��2��69   $	��300��6M   $	��300��6Y   �� 5      $	��XII��6   $��19(�6'    �� Left$	 140��65   
 �� Top$ 10��6G   �� 5      $��VI��6   $��19(�6&   $	 140��64   $	 260��6F   5      �� 5      -   5         ��Name$ second��5      	 �� Y2$
 -110��5      
���  ��$��3��5      $��Center=�5      $	��Top=�5      $��	0,145,0,0q�5       J� RenderTransformOrigin$ .5, .5&�5      z�5      �� 5       �� Angle$ 90Q�6&   5      �� 5      -   5        $ minute��5      $	 -95��5      
���   �$��3��5       $��Center=�5!      $	��Top=�5"      $��	0,145,0,0q�5#      $ .5, .5&�5$      z�5%      �� 5&      $ 45Q�6&   5(      �� 5)      -   5        $
 hour��5)      $	 -75��5*      
���   �$��3��5,      $��Center=�5-      $	��Top=�5.      $��	0,145,0,0q�5/      $ .5, .5&�50      z�51      �� 52      $ 0Q�6&   54      55      (  "System.Windows.Controls.DatePicker  56   
   -   5        	  Name$	 
datepicker��56   s   $��Center=�6   $��Bottom=�62   $��0,0,0,65q�6M   $y�Hidden=�6_   
   SelectedDateFormat$
 Short=�6�   6�   �� 57   
   -   5         ��Name$ clockTextBlock��57      $��48(�6,   
���   �$��Center=�6M   $��Bottom=�6j   $��	0,0,0,150q�6�   6�   �� 58   
   -   5        $ dateTextBlock��58      $��35(�6+   
���   �$��Center=�6L   $��Bottom=�6i   $��0,0,0,65q�6�   6�   59      5:      