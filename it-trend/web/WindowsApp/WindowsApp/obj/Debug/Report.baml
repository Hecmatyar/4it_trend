   M S B A M L   `   `   `  ����g  cMicrosoft.ReportViewer.WinForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3atSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms  5   	   E AWindowsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WindowsApp
WindowsApp 5   	      WindowsApp.Report   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   *localclr-namespace:WindowsApp     5   	   -   5          � Title$  Report��5	   	   $	��800��6   $
��1020��6%   .��5
      � $��Center=�6   $
��1000��6(   .+�5   
   �� -   5         ��Name$ label��5      $)��#Отчет о проведении ��6   $
��Left=�6=   $��2,18,0,0q�6X   $	��Top=�6j   $��14.667(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataGrid1��5      $��	0,53,0,10q�6&      AutoGenerateColumns .     HorizontalGridLinesBrush �	#FFE6E6E6   VerticalGridLinesBrush
 ��������	#FFB6B6B6
�������   CanUserResizeColumns .     CanUserReorderColumns .     GridLinesVisibility$ 
Horizontal=�65  	   
IsReadOnly	 . 
   HeadersVisibility$
 Column=�6h  $
��1000��6�  $��Center=�6�  $��13.333(�6�     	RowHeight$ 40Q�6�     ColumnHeaderHeight$ 45Q�6�     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Личный номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Ln+  5      $, &Фамилия Имя Отчество��6%   $	 240 6C    6O   �� *Fio+  5      $ Код должности��6%   $ 90 6<    6G   �� *Kd+  5      $  Специальность��6%   $	 180 6<    6H   �� *Sp+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5      $, &Электробезопасность��6%   $	 180 6B    6N   �� *Ap+ 5      �� 5      .�5      ��  � ��$
 Wrap=�6G   5      5        5      $- 'Техника безопасности��6%   $	 180 6C    6O   �� *Es+ 5       �� 5!      .�5"      ��  � ��$
 Wrap=�6G   5#      5%       � 	Resources 5(       �� Color=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� TextAlignment��%�  (��       5*      * SystemColors.HighlightBrushKey+)'  '     �� 5)      $ 	#FFCBCBCB��5+      �� 5,      "  6   .�5-      ��  � ��$
 Bold"�63   �� 5.       � ��$ 4q�60   �� 5/       � ��
 �����63   �� 50       � ��$ 25��6/   �� 51       � �� �	#FF36363663   �� 52       � ��$
 Left=�6<   �� 53       � �� 54      �� 55      .R�56   "   �� $
��Wrap=�6,   $ Center=�6@   ��6W   �� 6j   57      59      5:      5;      5<      �� 5=   
   -   5         ��Name$ PrintButton��5=      $+��%Распечатать таблицу��6&   $	��Top=�6D   ���	#FF5884B8$��16(�6t    � Cursor$
 Hand��6�   $��30��6�   $��Right=�6�   $	��190��6�   $��0,18,1,0q�6�   $��Segoe UI Light)�6�   ��5>      �� 5?      " ��6   .�5@      ��  � �� �	#FF50AA7564   �� 5A       � ��
 �����63   �� 5B       � ��
 �   �63   �� 5C       � �� 5D      �� 5E       �� 
TargetType" ��6.   .R�5F   "   �� #��z��6)   ���	#FF50AA75 �� CornerRadius$ 3,3,3,3��6l   $��1,1,1,1q�6�   ._�5G   &   �� $��Center=�67   $��Center=�6T   5H   #   5I      5K       �� Triggers 5L      P� 5M       P� Property �@J�IsMouseOver P� Value . . �5N      ��  � �� �	#FF50AA756;   �� 5O       � ��
 �����6;   5P      5R      5T      �� 5U   
   -   5        $ OverAttestation��5U      $-��'Завершить аттестацию��6*   $	��Top=�6I   ���	#FFBD3C3C$��16(�6y   $
 Hand��6�   $��30��6�   $��Right=�6�   $	��190��6�   $��
0,18,199,0q�6�   $��Segoe UI Light)�6�   ��5V      �� 5W      " ��6   .�5X      ��  � �� �	#FFBD3C3C64   �� 5Y       � ��
 �����63   �� 5Z       � ��
 �   �63   �� 5[       � �� 5\      �� 5]      " ��6.   .R�5^   "   �� #��z��6)   ���	#FFBD3C3C$ 3,3,3,3��6l   $��1,1,1,1q�6�   ._�5_   &   �� $��Center=�67   $��Center=�6T   5`   #   5a      5c       5d      P� 5e       �@J�IsMouseOver . . �5f      ��  � �� �	#FFBD3C3C6;   �� 5g       � ��
 �����6;   5h      5j      5l      5n      5o      