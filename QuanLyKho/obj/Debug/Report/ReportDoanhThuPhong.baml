   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:QuanLyKho.ViewModelQuanLyKho.ViewModel  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      *    $QuanLyKho.Report.ReportDoanhThuPhong   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:QuanLyKho.ViewModel     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5
         RpDoanhThuPhongVM  � DataContext#  [  5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��10q�6!   $��Center=�6-   $��34(�6J   $4��.THỐNG KÊ DOANH THU CỦA PHÒNG THEO THÁNG��6X   � 5   
   $��1��6   .+�5      �� -   5         ��Name$ cbMonth��5      $��0��6(   $��10q�68   $��Center=�6D   $��18(�6a   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Select Month��5       �� 
IsEditable . $	��150��5       & "MaterialDesignFloatingHintComboBox#��[ 5       �� SelectedValuePath$ Content��5       �� SelectedValue 5      �� *SelectedItem+ �� Mode$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5       /  )System.Windows.Interactivity.EventTrigger  5!      	   	EventName$	 SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5"      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *SelectionChangedCommand+5#      .@�5&      ��  �� 
IsSelected . $��1��61   �� 5'      $��2��6   �� 5(      $��3��6   �� 5)      $��4��6   �� 5*      $��5��6   �� 5+      $��6��6   �� 5,      $��7��6   �� 5-      $��8��6   �� 5.      $��9��6   �� 5/      $��10��6   �� 50      $��11��6   �� 51      $��12��6   53      55      #  LiveCharts.Wpf.CartesianChart  56   
   $��2��6   &   LiveCharts.Wpf.Charts.Base.Chart   Series 58      !  LiveCharts.Wpf.ColumnSeries  	  LiveCharts.Wpf.Series 	  Title$ 	Doanh Thu��6#    	  
DataLabels .  	  
Foreground
 ��+�� 	  Values 65   �� *ColumnSeriesHDCounts+6�      AxisX 5;      
  LiveCharts.Wpf.Axis
   
  Labels 6   �� *AxisListNameHD+6@      AxisY 5>      
   
  Title$ 
Case count��6   60   5@      5A      5B      