   M S B A M L   `   `   `  ����D  @DrugStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DrugStore.Menu_ElementsDrugStore.Menu_Elements  5      2    ,DrugStore.Menu_Elements.InventoryUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:DrugStore.Menu_Elements     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignPaper#���   5
        MaterialDesignBody#���  5      $��Regular"�5      $��14(�5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $��74��6*   �� 5      .+�5   
   � $��0��6   $��10,10,10,10q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6*   $��Center=�69   $��0,0,5,0q�6T   #���  5!      �� 5"      -   5         ��Name$ Search_Text��5&      $��1��5"      $��Center=�6*    ( $MaterialDesignFilledTextFieldTextBox#���  5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��5$      $	��585��66   5&      �� 5'      -   5        $��2��5'      $��New Drug��6)   $��Center=�6<     MaterialDesignRaisedButton#���  5(      $��5,0,0,0q�6B   5)      5*      5+      � 5,   
   $��1��6   $��0,5,0,0q�6     5-      �� 5.      $��* �6    �� 5/      $��* �6    �� 50      $��* �6     52      �� 53      $
��133* �6#   �� 54      $	��79* �6#   �� 55      $
��188* �6#   �� 56      $
��133* �6#   �� 57      $
��133* �6#   �� 58      $
��133* �6#   .+�5;      �� $��3��6   $��0��6)   $ 
Horizontal=�66   $��112,4,24,16q�6O   $��3��6d   .+�5<      �� $��0,0,10,0q�6   $��ID Code:��6.   $��Center=�6>   �� 5=      -   5        $ txtProductCode��5=      $��87��6[   $��22��6f   �� 5>      -   5        $��2��5>      $
��Sort��6)   $��Center=�68   #���  5?      $��5,0,0,0q�6B   $��64��5@   ,   5A      �� 5D      $��0��6   $��4��6)   $��0��6=   $ 
Horizontal=�6J   $��	10,0,2,22q�6c   .+�5E      �� $��0,0,10,0q�6   $��Type:��6.   $��Center=�6;   �� 5F      -   5         ��Name$ cmbProductType��5F      $	��412��63   $��24��6r   .@�5G      �� .��6#   	Nothing6,   �� 5H      .��6#   Thuốc ho (cough medicine)6>   �� 5I      .��6#   &$Thuốc giảm đau (pain relievers)6D   �� 5J      .��6#   &$Thuốc giảm cảm (decongestants)6C   �� 5K      .��6#   1/Thuốc chống viêm (anti-inflammatory drugs)6O   �� 5L      .��6#   #!Thuốc kháng sinh (antibiotics)6C   �� 5M      .��6#   *(Thuốc kháng histamin (antihistamines)6J   �� 5N      .��6#   '%Thuốc giảm nhiệt (antipyretics)6D   �� 5O      .��6#   %#Thuốc tiêu hóa (digestive aids)6D   �� 5P      .��6#   PNThuốc bổ sung vitamin và khoáng chất (vitamin and mineral supplements)6k   �� 5Q      .��6#   #!Thuốc đau dạ dày (antacids)6@   �� 5R      .��6#   Thuốc an thần (sedatives)6>   �� 5S      .��6#   -+Thuốc chống co giật (anticonvulsants)6J   �� 5T      .��6#   [YThuốc hoạt động trên hệ thần kinh trung ương (central nervous system drugs)6p   �� 5U      .��6#   +)Thuốc tim mạch (cardiovascular drugs)6J   �� 5V      .��6#   .,Thuốc hạ huyết áp (antihypertensives)6J   �� 5W      .��6#   =;Thuốc điều trị tiểu đường (antidiabetic drugs)6S   �� 5X      .��6#   HFThuốc hoạt động trên hệ tiết niệu (urinary system drugs)6]   �� 5Y      .��6#   ECThuốc điều trị rối loạn tâm thần (psychotropic drugs)6Z   �� 5Z      .��6#   LJThuốc điều trị tiền mãn kinh (hormone replacement therapy drugs)6e   �� 5[      .��6#   GEThuốc điều trị bệnh lý tiểu hóa (gastrointestinal drugs)6]   5\      5]      �� 5_      $��3��6   $ 
Horizontal=�6-   $��
10,34,73,0q�6F   $��2��6Z   .+�5`      �� $��Price:��6   $��Center=�6*   �� 5a      -   5        $ txtPrice��5a      $��10,0,0,0q�6M   $��Center=�6_   $	��138��6z   $��22��6�   �� 5b      -   5        $ cmbPriceOption��5b      $��10,0,0,0q�63   $	��116��6E   $��26��6�   .@�5c      �� .��6#   	Nothing6,   �� 5d      .��6#   Greater than61   �� 5e      .��6#   	Less than6.   �� 5f      .��6#   
Equal to6-   5g      5h      �� 5j      $��2��6   $��4��6)   $ 
Horizontal=�6=   $��121,38,133,0q�6V   $��2��6l   .+�5k      �� $��	Quantity:��6   $��Center=�6-   �� 5l      -   5        $ txtQuantity��5l      $��10,0,0,0q�6/   $��Center=�6A   $	��133��6\   $��23��6h   �� 5m      -	   5        $ cmbQuantityOption��5m      $��10,0,0,0q�66   $	��121��6H   $��24��6�   .@�5n      �� $��Nothing��6#   �� 5o      $��Greater than��6#   �� 5p      $��	Less than��6#   �� 5q      $��Equal to��6#   5r      5s      �� 5v      $��0��6   $��2��6)   $ 
Horizontal=�66   $��3,8,1,8q�6O   $��3��6`   .+�5w      �� $��Expiry Date:��6   $��Center=�60   �� 5x      -
   5        $ txtExpirationDate��5x      $��10,0,0,0q�65   $��Center=�6G   $	��133��6b   $��23��6n   �� 5y      -   5        $ cmbExpirationOption��5y      $��10,0,0,0q�68   $	��121��6J   $��24��6�   .@�5z      �� $��Nothing��6#   �� 5{      $��>=��6#   �� 5|      $��Expired��6#   5}      5~      5�      �� 5�   
   -   5         ��Name$ drugListView��5�   5   $��2��6   $��10,10,10,10q�6    #���   5�      ��5�      �� *Drugs+ �� View 5�      �� 5�      .P�5�      �� $��ID��6%   	 �� Width$
	 Auto��6U   
 �� DisplayMemberBinding
 61   �� *ID+6U   �� 5�      $��Avatar��6%    �� CellTemplate 5�      �� 5�      .R�5�   "   �� $	��100��6(   $	��100��64   ��5�   &   �� 5�   *    �� 	UriSource 66   �� *Avatar+5�   #   5�      5�      �� 5�      $��Product Name��6%   $
	 Auto��6a   
 6;   �� *Name+6a   �� 5�      $��Product Type��6%   
 6;   �� *	DrugTypes+�� 5�      $��
Unit Price��6%   $
	 Auto��6`   
 69   �� *Price+6`   �� 5�      $
��Unit��6%   $
	 Auto��6^   
 63   �� *	DrugUnits+6^   �� 5�      $��Quantity��6%   $
	 Auto��6a   
 67   �� *
Quantity+6a   �� 5�      $��Import Date��6%   $
	 Auto��6f   
 6:   �� *
ImportDate+6f   �� 5�      $��Expiration Information��6%   $
	 Auto��6q   
 6E   �� *
ExpiryDate+6q   �� 5�      $��Description��6%   $
	 Auto��6:    5�      �� 5�      .R�5�   "   �� $
��Wrap=�6I   $	��200��6]   ��6,   �� *Description+6]   5�      5�      5�       � 	Resources 5�       �� 
TargetType��%E   '��       �� 5�      " ��6   .�5�      -   5        5�      5�      5�      5�      5�      