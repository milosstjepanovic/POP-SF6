   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   )    #POP_SF_06_2016_GUI.GUI.AkcijaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  AkcijaWindow��5   	   $��425.2��6   $	��741��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   ��5	      �� 5
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
   &   System.Windows.Controls.DataGrid  -   5        $��dgAkcija��5"      $
��Left=�6#   $	��275��6>   $	��Top=�6K   $	��548��6c   	   
IsReadOnly	 . 
   CanUserAddRows
 .  $��0,74,0,0q�5#         AutoGenerateColumns .  �� SelectedItem 6u   ��  �� Path$ IzabranaAkcija��� 5$   
   -   5        $��btnDodajAkciju��5$   P   $	��105��6   $��Right=�6   $��0,77,24.4,279q�69   .��6�   Dodaj akciju6�   �� 5%   
   -   5        $��btnIzmeniAkciju��5%   Q   $	��105��6   $��Right=�6   $��0,133,24.4,223q�69   .��5&   /   Izmeni akciju6>   �� 5'   
   -   5        $��btnObrisiAkciju��5'   Q   $	��105��6   $��Right=�6   $��0,190,24.4,166q�69   .��5(   /   Obrisi akciju6>   �� 5)   
   -   5        $��btnIzlaz��5)   P   $	��105��6   $��Right=�6   $��0,309,24.4,47q�69   .��5*   (   Izlaz6/   �� 5+   
   $��Pretrazi po:��6   $
��Left=�6'   $��0,10,0,0q�6B   $	��Top=�6T   $��86��6l   �� 5,   
   -   5        $��
tbPretrazi��5-      $
��Left=�5,      $��23��6-   $��	86,46,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��138��6x   5-   $   �� 5.   
   $��Sortiraj po:��6   $
��Left=�6'   $��
356,40,0,0q�6B   $	��Top=�6V   $��86��6n   �� 5/   
   -   5        $��cmbSortiranje��5/   f   $
��Left=�6   $��
447,43,0,0q�6.   $	��Top=�6B   $	��101��6Z   50      �� 51   
   -   5        $��cmbPretraga��52      $
��Left=�51      $��	86,13,0,0q�6.   $	��Top=�6A   $	��138��6Y   52      �� 53   
   $��	Vrednost:��6   $
��Left=�6$   $��0,43,0,0q�6?   $	��Top=�6Q   $��73��6i   54      55      