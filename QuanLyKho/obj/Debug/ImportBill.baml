   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   G(clr-namespace:QuanLyKho.UserControlKteamQuanLyKho.UserControlKteam  5   
       QuanLyKho.ImportBill   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   7uc(clr-namespace:QuanLyKho.UserControlKteam     5   
   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    	 hdnVM � DataContext# [ 5   	    � Title$ Hoá Đơn Nhập Hàng��5   	   $	��500��6#   $	��700��60   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      -   'QuanLyKho.UserControlKteam.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 window��6J   5      � 5!   
   $��1��6    5"      �� 5#      $
��auto �6    60   �� 5$      $
��auto �6    60   �� 5%      6"   .+�5)      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5*      � $��0 0 0 10q�6   .+�5+      �� $��5 5 15 5q�6Z   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên nhân viên��6l    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *tenNV+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5,      5-        5/      $��1��6"   $��5q�6/   .��50      � .+�51      �� $��
Quay Lại��6>   $��5q�6Q   $	��100��6\   ��6   �� *ResetCommand+6j   �� 52      $��Show CTHD nhập��68   $��5q�6Q   $	��150��6\   ��6   �� *ShowHD+6j   53      54        56      $��2��6"   $��5q�6/   $��Stretch=�6:   .��57      �� $
��Auto=�6   .��58      �� ��6   �� *
listHDNhap+ �� SelectedItem 6B   �� *Selecteditem+ �� Mode$ TwoWay=� �� View 59      �� 5:      .P�5;   "   �� $ ��Id hóa đơn nhập hàng��61    �� DisplayMemberBinding 6O   �� *ID_HDNHAPHANG+6�   �� 5<   "   $��Tên nhân viên��61    6H   �� *NHANVIEN.HOTEN+6z   5=      5?      5@      5A      5B      5C      5D      