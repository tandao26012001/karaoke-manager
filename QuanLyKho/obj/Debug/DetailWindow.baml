   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   G(clr-namespace:QuanLyKho.UserControlKteamQuanLyKho.UserControlKteam  5	   
       QuanLyKho.DetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   7uc(clr-namespace:QuanLyKho.UserControlKteam     5	   
   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  window��5   	      cthdPhongVM � DataContext# [  5   	     MaterialDesignBody#���  5   	   $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$" Chi tiết hóa đơn phòng��5   	   $	��500��6(   $	��700��65   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      -   'QuanLyKho.UserControlKteam.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 window��6J   5      � 5!   
   $��1��6    5"      �� 5#      $
��auto �6    60   �� 5$      $
��auto �6    60   �� 5%      6"   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5*      � $��0 0 0 10q�6   .+�5+      �� $��5 5 15 5q�6Z   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên mặt hàng��6l    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *tenmh+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5,      $��5 5 15 5q�6\   $ Số Lượng��6n   #��[ 6�   ��6   �� *	Soluong+$ PropertyChanged=�6�   �� 5-      $��5 5 15 5q�6[   $ 
Đơn Giá��6m   #��[ 6�   ��6   �� *Dongia+$ PropertyChanged=�6�   �� 5.      $��5 5 15 5q�6^   $ ID mặt hàng��6p   #��[ 6�   ��6   �� *	IDmathang+$ PropertyChanged=�6�   �� 5/      $��5 5 15 5q�6\   $ 	ID Phòng��6n   #��[ 6�   ��6   �� *	IDphong+$ PropertyChanged=�6�   �� 50      $��5 5 15 5q�6^   $ ID Hoá Đơn Phòng��6p   #��[ 6�   ��6   �� *	IDhdphong+$ PropertyChanged=�6�   52      53        55      $��1��6"   $��5q�6/   .��56      � .+�57      �� $��Thêm��6<   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6d   �� 58      $��Sửa��6=   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6e   �� 59      $��Xóa��6?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6g   �� 5:       $  MaterialDesignRaisedAccentButton#��[ 6?    � ToolTip$5 /Resource name: MaterialDesignRaisedAccentButton��6y   $��
Quay Lại��6�   ��6   �� *ReturnCommand+6�   5;      5<        5>      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5?      �� $
��Auto=�6   .��5@      �� ��6   �� *
listCTHDPh+ �� SelectedItem 6B   �� *SelectedItems+ �� Mode$ TwoWay=� �� View 5A      �� 5B      .P�5C   "   �� $��	Id Phòng��61    �� DisplayMemberBinding 6C   �� *
ID_PHONG+6o   �� 5D   "   $��Tên mặt hàng��61    6H   �� *MAT_HANG.TEN_MATHANG+6�   �� 5E   "   $��Số lượng��61    6C   �� *	SOLUONG+6n   �� 5F   "   $��
Đơn giá��61    6B   �� *DONGIA+6l   �� 5G   "   $��Id hoá đơn phòng��61    6K   �� *
ID_HDPHONG+6y   5H      5J      5K      5L      5M      5N      5O      