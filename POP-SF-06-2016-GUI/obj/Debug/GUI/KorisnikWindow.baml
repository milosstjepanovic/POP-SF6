   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   +    %POP_SF_06_2016_GUI.GUI.KorisnikWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  KorisnikWindow��5   	   $��421.2��6    $	��741��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   ��5
      �� 5   
    �� ImageSource$: 4/POP-SF-06-2016-GUI;component/slike/Background11.jpg��6    �� Opacity$	 1.5Q�6X    � 	Resources 5       �� 
TargetType �� Property �� Value��%^  '��       '��     '�� �    '�� �    �� 5   
   " ��6   .�5      ��  � �� �	#FF0B14886+   �� 5       � ��
 �   �6,   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��$ 14(�6)   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6,   5       5!      .��5"      � .+�5#   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 
dgKorisnik��5#       $��0��6   $
��Left=�64   $	��Top=�6O   $	��275��6g   $	��548��6t   
   AutoGenerateColumns
 .    
IsReadOnly .    CanUserAddRows .  $��2,78,0,0q�5%       �� SelectedItem 6%   ��  �� Path$ IzabraniKorisnik��� 5&   
   -   5        $��btnDodajKorisnika��5&   9   $	��120��6   $��Right=�6   $��0,78,22.4,273.2q�5'   1   .��6J   Dodaj korisnika6[   �� 5(   
   -   5        $��btnIzmeniKorisnika��5)      $	��120��5(      $��Right=�6   $��0,133,22.4,218.2q�69   .��5)   L   Izmeni korisnika6^   �� 5*   
   -   5        $��btnObrisiKorisnika��5+      $	��120��5*      $��Right=�6   $��0,189,22.4,162.2q�69   .��5+   L   Obrisi korisnika6^   �� 5,   
   -   5        $��btnIzlaz��5-      $	��120��5,      $��Right=�6   $��0,313,22.4,38.2q�69   .��5-   8   Izlaz6?   �� 5.   
   $��Pretrazi po:��6   $
��Left=�6'   $��2,10,0,0q�6B   $	��Top=�6T   $��91��6l   �� 5/   
   -   5        $��
tbPretrazi��50      $
��Left=�5/      $��23��6-   $��	98,47,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   $	��120��6x   50   $   �� 51   
   $��Sortiraj po:��6   $
��Left=�6'   $��
339,44,0,0q�6B   $	��Top=�6V   $��86��6n   �� 52   
   -   5        $��cmbSortiranje��52   f   $
��Left=�6   $��
430,47,0,0q�6.   $	��Top=�6B   $	��120��6Z   6{   �� 53   
   -   5        $��cmbPretraga��53   e   $
��Left=�6   $��	98,13,0,0q�6.   $	��Top=�6A   $	��120��6Y   6e   �� 54   
   $��	Vrednost:��6   $
��Left=�6$   $��2,44,0,0q�6?   $	��Top=�6Q   $��72��6i   55      56      