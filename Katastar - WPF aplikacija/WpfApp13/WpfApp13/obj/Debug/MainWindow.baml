   M S B A M L   `   `   `  ����C  ?WpfApp13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfApp13WpfApp13  5   	       WpfApp13.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfApp13     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         Opstine �� Orientation��%�   &	        �� 5
   
   .R�5      �� $ 
Horizontal=�6   $��3q�62   .+�5      �� ��6   �� *Naziv+5      5      5      .��5      � .+�5   
   �� $��Katastarske opstine��6   $
��Left=�6.   $��	10,55,0,0q�6I   $	��Top=�6\   �� 5   
   -   5         ��Name$ cbKatOpstine��5      $
��Left=�6)   $��
128,59,0,0q�6D   $	��Top=�6X   $	��120��6p   #��[  6|   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5         AutoGenerateColumns .  $
��Left=�6p   $	��207��6�   $��	23,97,0,0q�6�   $	��Top=�6�   $	��505��6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��Brisanje��5      61   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6C   	   Header$	 Sifra parcele��6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *	IDParcele+6N     5      $	 110 6B   $	 Povrsina ( u arima )��6N   
 6%   �� *
Povrsina+6N     5      $	 120 6D   $	 
Vlasnistvo��6P   
 6%   �� *
Vlasnistvo+6P     5      $ * 6@   $	 Adresa��6J   
 6%   �� *Adresa+6J      RowDetailsTemplate 5      �� 5       .R�5!      �� $��0q�6   
������� �� Padding$ 10q�6M   ._�5"      �  � ColumnDefinitions 5#      �� 5$   "   $	��100 �63   �� 5%   "   $	��100 �63   �� 5&   "   $	��100 �63   �� 5'   "   $	��100 �63    � RowDefinitions 5)      �� 5*   "   $
��Auto �60   �� 5+   "   $
��Auto �60   .+�5-      �� $��0��6(   $��0��68   $��10,0,0,0q�6E   $
��Left=�6W   $��Center=�6r   $��Sifra objekta��6�   �� 5.       ��Name$ txtIDObjekta��6&   $��0��6<   $��1��6I   $��1q�6Y   {�.  $��35��6v   �� 5/      $��0��6(   $��1��68   $��Vlasnik��6E   $��10,0,0,0q�6T   $
��Left=�6f   $��Center=�6�   �� 50      $ 
txtVlasnik��6&   $��1��6:   $��1��6J   $��1q�6W   {�.  $��35��6t   �� 51      $��0��6(   $��2��65   $��
Kvadratura��6E   $��10,0,0,0q�6W   $��Center=�6i   $
��Left=�6�   �� 52      $ txtKvadratura��6&   $��0��6=   $��3��6J   $��1q�6Z   $��35��6e   {�.  6t   �� 53      $��2��6(   $��2��65   $��
Uknjiženo��6E   $��10,0,0,0q�6V   $��Center=�6h   $
��Left=�6�   �� 54       ��Name$ cbUknjizeno��6'   $��1��6<   $��3��6I   $��1q�6Y   $��35��6d   {�.  6s   56      57      58      5:      �� 5;   
   $ ��Promena vlasnistva parcele��6   $
��Left=�67   $	��273��6R   $��
566,81,0,0q�6_   $	��Top=�6s   $	��216��6�   .��5<      � $
��Left=�6   $	��238��6.   $��
10,10,-2,0q�6;   $	��Top=�6O   $	��196��6g   .+�5=      �� $��Sifra parcele��6   $
��Left=�60   $��	10,24,0,0q�6K   $	��Top=�6^   �� 5>      -   5        $ tbSifraParcele��5>      $
��Left=�62   $��23��6M   $��	90,26,0,0q�6Y    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $��96��6�   6�   �� 5?      -   5         ��Name$ gbVlasnistvo��5?      {�.  $��
Vlasnistvo��6C   $
��Left=�6W   $	��108��6r   $��	10,55,0,0q�6   $	��Top=�6�   $	��176��6�   .��5@      � -   5         �Name$ gridVlasnistvo��5@      $
��Left=�63   $��77��6N   $��	10,8,-2,0q�6Z   $	��Top=�6m   $	��156��6�   .+�5A      	� $��privatno��6&   $
��Left=�69   $��	25,30,0,0q�6T   $	��Top=�6g   	� 5B      $��drzavno��6&   $
��Left=�68   $��	25,10,0,0q�6S   $	��Top=�6f   	� 5C      $��na koriscenje��6&   $
��Left=�6>   $��	25,51,0,0q�6Y   $	��Top=�6l   5D      5E      �� 5F      -   5         ��Name$ 	btnIzmeni��5F      $��Izmeni��6,   $
��Left=�6=   $��
45,192,0,0q�6X   $	��Top=�6l   $��75��6�   6�   5G      5H      �� 5I   
   $��Neuknjizeno��6   $
��Left=�6(   $��90��6C   $��
23,320,0,0q�6O   $	��Top=�6c   $	��479��6{   .��5J      � $
��Left=�6   $��55��6.   $��	10,10,0,0q�6:   $	��Top=�6M   $	��449��6e   .+�5K      �� $0��*Broj neuknjizenih na odabranoj opstini je ��6   $
��Left=�6M   $��	10,19,0,0q�6h   $	��Top=�6{   �� 5L      -	   5         ��Name$ tbNeuknjizeni��5L      $
��Left=�63   $��
245,24,0,0q�6N   $
��Wrap=�6b   $	��Top=�6v   5M      5N      o� 5O   
   $
��Left=�6   $��30��6*   $	��Top=�66   $	��137��6N   .@�5P      m� $��Rad sa objektima��6   .@�5Q      m� -
   5        $��Unos novog objekta��5Q      67   5R      5S      5T      5U      