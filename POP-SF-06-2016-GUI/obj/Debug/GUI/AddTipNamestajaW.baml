   M S B A M L   `   `   `  ����M  IPOP-SF-06-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_06_2016_GUI.GUIPOP_SF_06_2016_GUI.GUI  5   	   -    'POP_SF_06_2016_GUI.GUI.AddTipNamestajaW   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_06_2016_GUI.GUI     5   	     � Title$  AddTipNamestajaW��5   	   $��167.737��6"   $��317.141��63    � 
ResizeMode$ NoResize=�6C    � WindowStartupLocation$ CenterScreen=�6Y   ��5	      �� 5
   
    �� ImageSource$: 4/POP-SF-06-2016-GUI;component/slike/Background11.jpg��6    �� Opacity$	 1.5Q�6X    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '��     �� 5   
   " ��6   .�5      ��  � �� �	#FF0B14886+   �� 5       � ��
 �   �6,   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      5      .��5      � .+�5   
   �� $��Naziv:��6   $
��Left=�6!   $��	44,27,0,0q�6<   $	��Top=�6O   $��62��6g   �� 5   
   -   5        $��tbNaziv��5      $
��Left=�5      $��23��6-   $��
142,30,0,0q�69   	 �� TextWrapping$
	 Wrap=�6M   $	��Top=�6a   $	��120��6y   .��5   !   ��5      �� 5       
 �� Path$
 Naziv�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5!      (  "POP_SF_06_2016_GUI.GUI.ValidString  5"      5$      .��5%      5&      �� 5(   
   -   5        $��
btnSacuvaj��5(   t   $��Sacuvaj��6   $
��Left=�6#   $��	44,95,0,0q�6>   $	��Top=�6Q   $��75��6i   $��25��6�   ��5)      �� 5*      " ��6   .�5+      ��  � {� .  62    �� Triggers 5,      ^� 5-       ^� 
Conditions 5.      �� 5/   "    �� Binding 6,   �� $
 (Validation.HasError)� �� ElementName$ tbNaziv�� �� Value	 False6p   .0�51      ��  � {� . 6:   �� 52       � �� �	#FF0B14886;   �� 53       � ��
 �   �6<   �� 54       � ��$
 Bold"�6;   �� 55       � ��$ Italic$�6:   �� 56       � ��
 �����6;   �� 57       � ��$ 14(�69   59      5;      5=      �� 5?   
   -   5        $��Odustani��5?   v   $��Odustani��6   $
��Left=�6$   $��
187,95,0,0q�6?   $	��Top=�6S   $��75��6k   $��25��6�   5A      5B      