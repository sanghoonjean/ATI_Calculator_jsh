   M S B A M L   `   `   `  ���� I  EWpfCalculator1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfCalculator1.ViewsWpfCalculator1.Views  E'clr-namespace:WpfCalculator1.ViewModelsWpfCalculator1.ViewModels  )    #WpfCalculator1.Views.MainWindowView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:WpfCalculator1.Views     >
viewmodels'clr-namespace:WpfCalculator1.ViewModels       � Title$  	계산기��$	��600��$	��500��$	��600��$	��600�� � 	Resources    BtnStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value  	BtnStyle2  	BtnStyle3��%M  &	        &	 �     &	 \    �� " ��.���  � �� �� " ��.R��� $��1q�#��z��$ 3��$��1q�
�������._�� .+��� $��Center=�$��Center=� P�  � ��$
	 true��. ���  � ��
 ������� " ��.���  � �� �� " ��.R��� $��1q�#��z��
�������._�� .+��� $��Center=�$��Center=���  � ��
 �������  � ��$ 9(��� " ��.���  � �� �� " ��.R��� $��1q�#��z��$ 3��$��1q�
�������._�� .+��� $��Center=�$��Center=���  � ��
 ����� P�  � ��$
	 true��. ���  � ��
 �����.��� $	��550��$	��500��
 � RowDefinitions
 �� $
��0.1* ��� $
��0.2* ��� $
��0.4* ��� $
��0.1* ��� $��1* �.+�]� $��0��$��False��.+��� $��50��$��20��#��[ $
��Left=��� $��50��$��20��#��[ $
��Left=��� $��50��$��20��#��[ $��Right=�.���� $��/Resources/clock.png���� -    ��Name$ lastTextBlock��$��Right=�$��1��$	��100��$��10q�$��15(����� *DisplayData+�� -   $ currentTextBlock��$��Right=�$��2��$	��100��$��10q�$��20(����� *	InputData+�� $��3�� �� Orientation$ 
Horizontal=�.+�� 
 �� $��1* � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��40��$��20��#��[ .��MC�� $��40��$��20��#��[ .��MR�� $��40��$��20��#��[ .��M+�� $��40��$��20��#��[ .��M-�� $��40��$��20��#��[ ���� *SaveMemoryCommand+.��MS� $��4��
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* �.+��� 
 � Tag$ Button_Percent��$��0��$��0��$��7��#��[  ���� *
DataInsert+.���� $��15��$��15��$*��$/Resources/percent_discount_icon.png���� $ Button_Allcancle��$��1��$��0��#��[  ���� *	DataClear+.��CE�� $ Button_cancle��$��2��$��0��#��[  ���� *	DataClear+.��C�� $ Button_Backspace��$��3��$��0��#��[  ���� *
DataBack+.���� $��15��$��15��$#��/Resources/backspace_icon.png���� $ Button_fraction��$��0��$��1��#��[  .��1/x�� $ Button_Double��$��1��$��1��#��[  .��X^2�� $ Button_Root��$��2��$��1��#��[  .��√�� $ Button_Divide��$��3��$��1��$��/��#��[  ���� *DataOperator+.���� $��15��$��15��$ ��/Resources/divide_icon.png���� $ Button_7��$��0��$��2��$��7��#��[ ���� *
DataInsert+.��7�� $ Button_8��$��1��$��2��$��8��#��[ ���� *
DataInsert+.��8�� $ Button_9��$��2��$��2��$��9��#��[ ���� *
DataInsert+.��9�� $ Button_Multi��$��3��$��2��$��*��#��[  ���� *DataOperator+.���� $��15��$��15��$��/Resources/x_icon.png���� $ Button_4��$��0��$��3��$��4��#��[ ���� *
DataInsert+.��4�� $ Button_5��$��1��$��3��$��5��#��[ ���� *
DataInsert+.��5�� $ Button_6��$��2��$��3��$��6��#��[ ���� *
DataInsert+.��6�� $ Button_Minus��$��3��$��3��$��-��#��[  ���� *DataOperator+.���� $��15��$��15��$��/Resources/minus_icon.png���� $ Button_1��$��0��$��4��$��1��#��[ ���� *
DataInsert+.��1�� $ Button_2��$��1��$��4��$��2��#��[ ���� *
DataInsert+.��2�� $ Button_3��$��2��$��4��$��3��#��[ ���� *
DataInsert+.��3�� $ Button_Plus��$��3��$��4��$��+��#��[  ���� *DataOperator+.��+�� $ Button_Negative��$��0��$��5��#��[ .��+/-�� $ Button_0��$��1��$��5��$��0��#��[ ���� *
DataInsert+.��0�� $ 
Button_Dot��$��2��$��5��#��[ .��.�� $ Button_Equal��$��3��$��5��#��[  ���� *DataCalculator+.���� $��15��$��15��$ ��/Resources/equals_icon.png��