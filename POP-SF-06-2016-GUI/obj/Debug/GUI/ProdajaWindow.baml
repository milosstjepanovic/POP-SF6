   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   *    $POP_SF_06_2016_GUI.GUI.ProdajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  ProdajaWindow��5   	   $��440.4��6   $	��741��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P   ��5	      �� 5
   
    �� ImageSource$: 4/POP-SF-06-2016-GUI;component/slike/Background11.jpg��6    �� Opacity$	 1.5Q�6X    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '��     '�� �    '�� �    �� 5   
   " ��6   .�5      ��  � �� �	#FF0B14886+   �� 5       � ��
 �   �6,   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      5       .��5!      � .+�5"   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgProdajaNamestaja��5"       $��0��6   $
��Left=�6<   $	��275��5#      $	��Top=�6   $	��548��67   
   AutoGenerateColumns
 .    
IsReadOnly .    CanUserAddRows .  $��0,75,0,0q�5$   <    �� SelectedItem 5"   W   ��  �� Path$ IzabranaProdaja�5$   <   �� 5%   
   -   5        $��btnDodajProdaju��5&      $	��115��5%      $��Right=�6   $��0,75,24.4,300.4q�5&   F   .��6_   Dodaj prodaju6n   �� 5'   
   -   5        $��btnObrisiProdaju��5(      $	��115��5'      $��Right=�6   $��0,133,24.4,242.4q�5(   H   .��6b   Obrisi prodaju6r   �� 5)   
   -   5        $��btnIzlaz��5*      $	��115��5)      $��Right=�6   $��0,315,24.4,60.4q�5*   8   .��6Q   Izlaz6X   �� 5+   
   $��Pretrazi po:��6   $
��Left=�6'   $��0,10,0,0q�6B   $	��Top=�6T   $��88��6l   �� 5,   
   -   5        $��
tbPretrazi��5-      $
��Left=�5,      $��23��6-   $��	98,47,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��120��6x   5-   $   �� 5.   
   $��Sortiraj po:��6   $
��Left=�6'   $��
334,44,0,0q�6B   $	��Top=�6V   $��90��6n   �� 5/   
   -   5        $��cmbSortiranje��5/   f   $
��Left=�6   $��
429,47,0,0q�6.   $	��Top=�6B   $	��119��6Z   50      �� 51   
   -   5        $��cmbPretraga��51   e   $
��Left=�6   $��	98,13,0,0q�6.   $	��Top=�6A   $	��120��6Y   6e   �� 52   
   $��	Vrednost:��6   $
��Left=�6$   $��0,44,0,0q�6?   $	��Top=�6Q   $��88��6i   53      54      