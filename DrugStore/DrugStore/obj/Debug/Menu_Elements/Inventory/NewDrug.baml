   M S B A M L   `   `   `  ����D  @DrugStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:DrugStore.Menu_Elements.Inventory!DrugStore.Menu_Elements.Inventory  5   	   /    )DrugStore.Menu_Elements.Inventory.NewDrug   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:DrugStore.Menu_Elements.Inventory     5   	     � Title$  New Drug��5   	   $	��600��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  J� RenderTransformOrigin$ 	0.524,0.5&�6    � ColumnDefinitions 5   
   �� 5      $
��429* �6   �� 5      $
��371* �6   .+�5   
   �� $��0��6   $��	33,35,5,0q�6%   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5       �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5!      �� $��Drug Name :��6    $��Center=�63   �� 5"      -   5         ��Name$ txtDrugName��5"      $��10,0,0,0q�63   $	��131��6E   $��21��6R   5#      �� 5&      $��2��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5'      �� $��0,0,10,0q�6    $��Drug Type :  ��62   $��Center=�6G   �� 5(      -   5         ��Name$ cmbDrugType��5(      $	��274��64   $��28��6s   .@�5)      �� $!��Thuốc ho (cough medicine)��6'   �� 5*      $*��$Thuốc giảm đau (pain relievers)��6'   �� 5+      $*��$Thuốc giảm cảm (decongestants)��6'   �� 5,      $5��/Thuốc chống viêm (anti-inflammatory drugs)��6'   �� 5-      $'��!Thuốc kháng sinh (antibiotics)��6'   �� 5.      $.��(Thuốc kháng histamin (antihistamines)��6'   �� 5/      $+��%Thuốc giảm nhiệt (antipyretics)��6'   �� 50      $)��#Thuốc tiêu hóa (digestive aids)��6'   �� 51      $T��NThuốc bổ sung vitamin và khoáng chất (vitamin and mineral supplements)��6'   �� 52      $'��!Thuốc đau dạ dày (antacids)��6'   �� 53      $#��Thuốc an thần (sedatives)��6'   �� 54      $1��+Thuốc chống co giật (anticonvulsants)��6'   �� 55      $_��YThuốc hoạt động trên hệ thần kinh trung ương (central nervous system drugs)��6'   �� 56      $/��)Thuốc tim mạch (cardiovascular drugs)��6'   �� 57      $2��,Thuốc hạ huyết áp (antihypertensives)��6'   �� 58      $A��;Thuốc điều trị tiểu đường (antidiabetic drugs)��6'   �� 59      $L��FThuốc hoạt động trên hệ tiết niệu (urinary system drugs)��6'   �� 5:      $I��CThuốc điều trị rối loạn tâm thần (psychotropic drugs)��6'   �� 5;      $P��JThuốc điều trị tiền mãn kinh (hormone replacement therapy drugs)��6'   �� 5<      $K��EThuốc điều trị bệnh lý tiểu hóa (gastrointestinal drugs)��6'   5=      5>      �� 5@      $��3��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5A      �� $��Price :           ��6    $��Center=�6:   �� 5B      -   5        $ txtPrice��5B      $��10,0,0,0q�60   $��Center=�6B   $	��131��6]   $��22��6i   5C      �� 5E      $��4��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5F      �� $��0,0,10,0q�6    $��Unit  :    ��62   $��Center=�6E   $��68��6`   �� 5G      -   5        $ cmbDrugUnit��5G       $	��272��65   $��28��6t   .@�5H      �� .��6'   Tablet6/   �� 5I      .��6'   Bottle6/   �� 5J      .��6'   Pack6-   5K      5L      �� 5N      $��5��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5O      �� $��Quantity :          ��6    $��Center=�6<   $��68��6W   �� 5P      -   5        $ txtQuantity��5P      $��10,0,0,0q�63   $��Center=�6E   $	��131��6`   $��22��6l   5Q      �� 5S      $��6��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5T      �� $��Import    :    ��6    $��0,0,10,0q�67   $��Center=�6I   $��68��6d   (  "System.Windows.Controls.DatePicker  5U      -   5        	  Name$	 dpImportDate��5U   !   $��0,0,10,0q�6_   $��Center=�6q   $	��131��6�   
   SelectedDate
 67   �� *ExpirationDate+6�   5V      �� 5X      $��7��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5Y      �� $��Expiration :   ��6    $��0,0,10,0q�67   $��Center=�6I     5Z      -   5        $	 dpExpirationDate��5Z   "   $��0,0,10,0q�6d   $��Center=�6v   $	��131��6�   
 6<   �� *ExpirationDate+6�   5[      �� 5\      $��8��6   $ 
Horizontal=�6*   $��5,5,5,10q�6C   .+�5]      �� $��Description :           ��6    $��69��6@   �� 5^      -   5        $ txtDescription��5^       �� TextWrapping$
 Wrap=�5_      $��Center=�5`      $��10,0,0,0q�5a      $	��270��5b      $	��154��6%   5c      �� 5d      $��9��6   $��5,5,5,25q�6*   .+�5e      � $��68��6   $	��380��6'    5f      �� 5g      $��* �6/   �� 5h      $��* �6/   .+�5k      �� -	   5        $��Create��5k   !   $��25(�6Y   $��1��6g   $��	20,0,34,0q�6w   ��63   �� *AddNewDrugCommand+��5l      �� 5m   "    �� 
TargetType" ��6(   .�5n   &   ��  �� Property � �� �� Value
 �����6C   �� 5o   &    � ��
 ��  �6C   �� 5p   &    � ��$ 15,10q�6@   �� 5q   &    � �� 5r   *   �� 5s   .    �� 
TargetType" ��6>   .R�5t   2   ��  ��Name$ border��69   #��z��6I   #��z��6s   #��z��6�    �� CornerRadius$ 5��6�   ._�5u   6   �� $��Center=�6G   $��Center=�6b   $��5q�6   5v   3    �� Triggers 5w   2   P� 5x   6    P� Property �@J�IsMouseOver P� Value . . �5y   :   ��  �� 
TargetName$ border��6A    � �� �#005E996k   5z   7   P� 5{   6    � �� . . �5|   :   �� $ border��6A    � �� �#00406B6k   5}   7   P� 5~   6    � {� .  . �5   :   ��  �@J�Opacity$	 0.5Q�6T   �� 5�   :    � ��
 �����6W   �� 5�   :    �@�Cursor$ Arrow��6S   5�   7   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      �� 5�   
   $��1��6   $��0,20,0,0q�6%   .+�5�      �� -
   5        $	��275��5�      $	��240��6!   ��5�      �� 5�      " ��6&   .R�5�      �� $	��200��6!   $	��200��6-   
�������$��0,10,0,0q�6Q   ._�5�      � .+�5�   "   ��  ��Name$ 
PART_Image��6(   $	��200��6<   $	��200��6H   $��UniformToFill=�6s   ��6U   �� *
AvatarPath+6s   �� 5�   "    ��Name$ TextChooseAvatar��6,   $��Choose Avatar��6F   $��Center=�6[   $��Center=�6v   $��20(�6�   5�      5�      5�      5�      5�      5�      5�      