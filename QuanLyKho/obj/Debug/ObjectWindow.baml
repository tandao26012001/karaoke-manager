   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   G(clr-namespace:QuanLyKho.UserControlKteamQuanLyKho.UserControlKteam  5
   
       QuanLyKho.ObjectWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   7uc(clr-namespace:QuanLyKho.UserControlKteam     5
   
   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  window��5   	      	mathangVM � DataContext# [  5   	     MaterialDesignBody#���  5   	   $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Mặt Hàng��5   	   $	��500��6   $	��700��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      -   'QuanLyKho.UserControlKteam.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 window��6J   5       � 5"   
   $��1��6    5#      �� 5$      $
��auto �6    60   �� 5%      $
��auto �6    60   �� 5&      6"   .+�5*      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5+      � $��0 0 0 10q�6   .+�5-      �� $��5 5 15 5q�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ID nha cung cap��6s    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *IDNhacungcap+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5.      $��5 5 15 5q�6_   $ Tên Mặt Hàng��6q   #��[ 6�   $��35��6�   ��6   �� *
Tenmathang+$ PropertyChanged=�6�   �� 5/      $��5 5 15 5q�6^   $ Đơn Vị Tính��6p   #��[ 6�   ��6   �� *	Donvitinh+$ PropertyChanged=�6�   �� 50      $��5 5 15 5q�6b   $ Ten nha cung cap��6t   #��[ 6�   ��6   �� *TenNhacungcap+$ PropertyChanged=�6�   51      52        54      $��1��6"   $��5q�6/   .��55      � .+�56      �� $��Thêm��6<   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6d   �� 57      $��Sửa��6=   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6e   �� 58      $��Xóa��6?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6g   �� 59      $��
Quay Lại��6>   $��5q�6Q   $	��100��6\   ��6   �� *ResetCommand+6j   5;      5<        5>      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5?      �� $
��Auto=�6   .��5@      �� ��6   �� *listMH+ �� SelectedItem 6>   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5A      �� 5B      .P�5C   "   �� $��Id mặt hàng��61    �� DisplayMemberBinding 6F   �� *
ID_MATHANG+6t   �� 5D   "   $��Tên nhà Cung Cấp��61    6K   �� *NHACUNGCAP.TEN_NHACUNGCAP+6�   �� 5E   "   $��Tên Mặt Hàng��61    6G   �� *TEN_MATHANG+6v   �� 5F   "   $��Đơn Vị Tính��61    6F   �� *	DONVITINH+6s   5G      5I      5J      5K      5L      5M      5N      