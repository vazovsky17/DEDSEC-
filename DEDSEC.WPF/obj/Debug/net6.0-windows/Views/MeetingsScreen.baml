   M S B A M L   `   `   `  ????  
DEDSEC.WPF%    DEDSEC.WPF.Views.MeetingsScreen   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?   ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5	      $
??auto ?6   ?? 5
      $??* ?6   .+?5   
   ?? $??0??5      $??0,20,0,0q?5         textBlockTitle#??[  5      $??Встречи??5      ?? 5   
   $??0??5        optionButton#??[ 5      ??5      ?? *AddMeetingCommand+y?5      ?? *	IsAdmin+   BooleanToVisibilityConverter ?? 	Converter# [ .??5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=?6(     optionButtonIcon#??[ 64   ?? 5      $??0,0,8,0q?6   $%??Добавить встречу??6-   5      5      ?? 5!   
   $??1??5"      $??	0,20,0,10q?5#      $
??Left=?5$      $??Center=?5%      $??18(?5&      $??SemiBold"?5'        ColorTextForeground#??[ 5(      ??5)      ?? * MeetingsViewModelsCountDisplay+&   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ MeetingsDataGrid??5-      $??2??5.        DataGridCellStyle1   	CellStyle# ?  5/        DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  50        DataGridRowStyle1   RowStyle# ?  52        DataGridStyle1#???  53      ??51      ?? *MeetingViewModels+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 56      
   CanUserResize$
 False??58         Header$ Название??59         
IsReadOnly$
 True??5:      1  +System.Windows.Controls.DataGridBoundColumn   Binding 57      ?? *Title+5:        5;      $	 * 5<      $
 False??5>      $ Описание??5?      $
 True??5@       5=      ?? *Description+5@        5A      $	 * 5B      $
 False??5D      $ Начало??5E      $
 True??5F       5C      ?? *	DateBegin+5F        5G      $	 * 5H      $
 False??5J      $ 
Конец??5K      $
 True??5L       5I      ?? *	DateEnd+5L        5M      $	 * 5N      $
 False??5P      $ Максимум??5Q      $
 True??5R       5O      ?? *MaxCountVisitorsDisplay+5R      4  .System.Windows.Controls.DataGridTemplateColumn  5S      $	 * 5T      $

 True??5U      $ Действия??5V      $
 True??5W         CellTemplate 5X      ?? 5Y      .R?5Z      ?? $ 
Horizontal=?6)   .+?5[   "   ?? $??5,0,0,0q?5\   %    	 gridFavoriteButton#??[	 5^   %   ??5]   %   ?? *AddToFeatureCommand+y?5_   %   ?? *IsUnfeature+ ?? UpdateSourceTrigger$ PropertyChanged=?# [ .??5`   &     $ 	HeartPlus=?6<    
 gridButtonIcon#??[
 6M   5a   #   ?? 5b   "   $??5,0,0,0q?5c   %     gridUnFavoriteButton#??[ 5e   %   ??5d   %   ?? *DeleteFromFeatureCommand+y?5f   %   ?? *	IsFeature+$ PropertyChanged=?# [ .??5g   &     $ 
HeartMinus=?6<   #??[
 6N   5h   #   ?? 5i   "   $??5,0,0,0q?5j   %     gridEditButton#??[ 5l   %   ??5k   %   ?? *EditCommand+y?5m   %   ?? *	IsAdmin+# [ .??5n   &     $ Pencil=?6<   #??[
 6J   5o   #   ?? 5p   "   $??5,0,0,0q?5q   %     gridDeleteButton#??[ 5s   %   ??5r   %   ?? *DeleteCommand+y?5t   %   ?? *	IsAdmin+# [ .??5u   &     $ Delete=?6<   #??[
 6J   5v   #   5w      5x      5z      5|      5}      5~      