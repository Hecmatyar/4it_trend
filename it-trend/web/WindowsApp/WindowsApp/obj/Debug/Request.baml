   M S B A M L   `   `   `  ����E  AWindowsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WindowsApp
WindowsApp  5   	       WindowsApp.Request   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WindowsApp     5   	   -   5          � Title$  Request��5   	   $	��600��6   $	��840��6&   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $)��#Отчет о проведении ��6   $
��Left=�6=   $��	10,18,0,0q�6X   $	��Top=�6k   $��14.667(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataGrid1��5      $��	0,54,0,10q�6&      AutoGenerateColumns .     HorizontalGridLinesBrush �	#FFE6E6E6   VerticalGridLinesBrush
 ��������	#FFB6B6B6
�������   CanUserResizeColumns .     CanUserReorderColumns .     GridLinesVisibility$ 
Horizontal=�6�   	   
IsReadOnly	 . 
   HeadersVisibility$
 Column=�62  $��13.333(�6M     	RowHeight$ 40Q�6_     ColumnHeaderHeight$ 45Q�6n  $	��770��6�   � 	Resources 5       �� Color=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� TextAlignment��%�  (��       5   	   * SystemColors.HighlightBrushKey+)'  '     �� 5      $ 	#FFCBCBCB��5   	   �� 5      "  6   .�5      ��  � ��$
 Bold"�63   �� 5       � ��$ 4q�60   �� 5       � ��
 �����63   �� 5       � ��$ 25��6/   �� 5       � �� �	#FF36363663   �� 5       � ��$
 Left=�6<   �� 5       � �� 5      �� 5      .R�5   "   �� $
��Wrap=�6,   $ Center=�6@   ��6W   �� 5      5      5      5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Личный номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Ln+  5#      $, &Фамилия Имя Отчество��6%   $	 260 6C    6O   �� *Fio+  5$      $ Код должности��6%   $	 100 6<    6H   �� *Kd+  5%      $ Разряд��6%   $ 80 65    6@   �� *Rn+   ElementStyle 5&      �� 5'      .�5(      ��  � ��$
 Wrap=�6G   5)      5+        5,      $% Решение комиссии��6%   $	 280 6?    6K   �� *Rc+ 5-      �� 5.      .�5/      ��  � ��$
 Wrap=�6G   50      52      55      �� 56   
   -   5         ��Name$ PrintButton��56      $+��%Распечатать таблицу��6&   $	��Top=�6D   ���	#FF5884B8$��16(�6t    � Cursor$
 Hand��6�   $��30��6�   $��Right=�6�   $	��190��6�   $��	0,17,11,0q�6�   $��Segoe UI Light)�6�   ��57      �� 58      " ��6   .�59      ��  � �� �	#FF50AA7564   �� 5:       � ��
 �����63   �� 5;       � ��
 �   �63   �� 5<       � �� 5=      �� 5>       �� 
TargetType" ��6.   .R�5?   "   �� #��z��6)   ���	#FF50AA75 �� CornerRadius$ 3,3,3,3��6l   $��1,1,1,1q�6�   ._�5@   &   �� $��Center=�67   $��Center=�6T   5A   #   5B      5D       �� Triggers 5E      P� 5F       P� Property �@J�IsMouseOver P� Value . . �5G      ��  � �� �	#FF50AA756;   �� 5H       � ��
 �����6;   5I      5K      5M      �� 5N   
   -   5        $ OverAttestation��5N      $-��'Завершить аттестацию��6*   $	��Top=�6I   ���	#FFBD3C3C$��16(�6y   $
 Hand��6�   $��30��6�   $��Right=�6�   $	��190��6�   $��
0,17,208,0q�6�   $��Segoe UI Light)�6�   ��5O      �� 5P      " ��6   .�5Q      ��  � �� �	#FFBD3C3C64   �� 5R       � ��
 �����63   �� 5S       � ��
 �   �63   �� 5T       � �� 5U      �� 5V      " ��6.   .R�5W   "   �� #��z��6)   ���	#FFBD3C3C$ 3,3,3,3��6l   $��1,1,1,1q�6�   ._�5X   &   �� $��Center=�67   $��Center=�6T   5Y   #   5Z      5\       5]      P� 5^       �@J�IsMouseOver . . �5_      ��  � �� �	#FFBD3C3C6;   �� 5`       � ��
 �����6;   5a      5c      5e      5g      5h      