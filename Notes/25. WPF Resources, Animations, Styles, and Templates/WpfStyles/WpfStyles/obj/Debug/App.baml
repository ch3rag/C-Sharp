   M S B A M L   `   `   `  ����D  @WpfStyles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfStyles	WpfStyles  5          WpfStyles.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:WpfStyles     5        �� 	Resources  5         BasicControlStyle �� 
TargetType �� Property �� Value  BigGreenButton �� Triggers ]� 
Conditions �� Property �� Value  TiltedButton �� BasedOn	 �� Angle  GrowingButtonStyle
 �� ScaleX �� ScaleY P� Property P� Value N� EnterActions �� TargetProperty	 W� To g� Duration N� ExitActions��%�  &	        &	 �     '�� �    &	 n    7  &	     �� 5   
   " ��6*   .�5      ��  � ��$ 14(�61   6>   �� 5	       � ��$ 40��6/   6<   �� 5
       �@�Cursor$
 Hand��6/   6>   5      �� 5   
   " ��6'   .�5      ��  � ��$ 20(�6)   66   �� 5       � ��$	 100��6'   65   �� 5       � ��$	 100��6&   64   �� 5       � ��
 � d �6?   �� 5       � ��
 � ���6<   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   66   �� 5       � ��$	 100��6&   64   �� 5       � ��$ 30��6'   64   �� 5       � ��$ 5q�60   6<   �� 5       � ��
 �  ��6:   �� 5       � ��$ Italic$�6*   6;    5      ]� 5"       5#      �� 5$       �@J�	IsFocused . 6H   �� 5%       �@J�IsMouseOver . 6J   /�5'      �� 5(       � ��
 � ���6H   5*      5,      �� 5.   
   " ��6&   8   .�5/      ��  � ��
 �����6;   �� 50       �@�LayoutTransform 51      �� 52      $	 20Q�6&   63   54      55      �� 58   
   " ��6+   .�59      ��  � ��$ 40��6'   64   �� 5:       � ��$	 100��6&   64   �� 5;       �@J�RenderTransformOrigin$ 0.5 0.5&�66   6H   �� 5<       � z� 5=      �� 5>      $
 1Q�6%   $ 1Q�60   6=   5@       5A      P� 5B       �@J�IsMouseOver .  5C      �� 5D      .��5E      �� .��5F   "   W� $/ )(RenderTransform).(ScaleTransform.ScaleX)�62   $	 1.1X�6x   $ 0:0:0.5D�6�   6�   W� 5G   "   $/ )(RenderTransform).(ScaleTransform.ScaleY)�62   $	 1.1X�6x   $ 0:0:0.5D�6�   6�   5H      5I       5K      �� 5L      .��5M      �� .��5N   "   W� $/ )(RenderTransform).(ScaleTransform.ScaleX)�62   $ 0:0:0.5D�6x   6�   W� 5O   "   $/ )(RenderTransform).(ScaleTransform.ScaleY)�62   $ 0:0:0.5D�6x   6�   5P      5Q      5S      5U      5W      5X      