   M S B A M L   `   `   `  ????  
DEDSEC.WPF"    DEDSEC.WPF.Views.GamesScreen   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?   ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5	      $
??auto ?6   ?? 5
      $??* ?6   .+?5   
   ?? $??0??5      $??0,20,0,0q?5         textBlockTitle#??[  5      $??Игры??5      ?? 5   
   $??0??5        optionButton#??[ 5      ??5      ?? *AddGameCommand+y?5      ?? *	IsAdmin+   BooleanToVisibilityConverter ?? 	Converter# [ .??5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=?6(     optionButtonIcon#??[ 64   ?? 5      $??0,0,8,0q?6   $??Добавить игру??6-   5      5      ?? 5!   
   $??1??5"      $??	0,20,0,10q?5#      $
??Left=?5$      $??Center=?5%      $??18(?5&      $??SemiBold"?5'        ColorTextForeground#??[ 5(      ??5)      ?? *GameViewModelsCountDisplay+&   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ GamesDataGrid??5-      $??2??5.        DataGridCellStyle1   	CellStyle# ?  5/        DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  50        DataGridRowStyle1   RowStyle# ?  52        DataGridStyle1#???  53      ??51      ?? *GameViewModels+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 56      
   CanUserResize$
 False??58         Header$ Название??59         
IsReadOnly$
 True??5:      1  +System.Windows.Controls.DataGridBoundColumn   Binding 57      ?? *Name+5:        5;      $	 * 5<      $
 False??5>      $ Описание??5?      $
 True??5@       5=      ?? *Description+5@        5A      $	 * 5B      $
 False??5D      $  Кол-во игроков??5E      $
 True??5F       5C      ?? *PlayersCount+5F      4  .System.Windows.Controls.DataGridTemplateColumn  5G      $	 * 5H      $
 False??5I      $ Действия??5J      $
 True??5K         CellTemplate 5L      ?? 5M      .R?5N      ?? $ 
Horizontal=?6)   .+?5O   "   ??  	 gridShowButton#??[	 6I   ??6)   ?? *ShowCommand+.??5P   &     $ Magnify=?6<    
 gridButtonIcon#??[
 6K   5Q   #   ?? 5R   "   $??5,0,0,0q?5S   %     gridFavoriteButton#??[ 5U   %   ??5T   %   ?? *AddToFavoriteCommand+y?5V   %   ?? *IsUnfavorite+ ?? UpdateSourceTrigger$ PropertyChanged=?# [ .??5W   &     $ 	HeartPlus=?6<   #??[
 6M   5X   #   ?? 5Y   "   $??5,0,0,0q?5Z   %     gridUnFavoriteButton#??[ 5\   %   ??5[   %   ?? *DeleteFromFavoriteCommand+y?5]   %   ?? *
IsFavorite+$ PropertyChanged=?# [ .??5^   &     $ 
HeartMinus=?6<   #??[
 6N   5_   #   ?? 5`   "   $??5,0,0,0q?5a   %     gridEditButton#??[ 5c   %   ??5b   %   ?? *EditCommand+y?5d   %   ?? *	IsAdmin+# [ .??5e   &     $ Pencil=?6<   #??[
 6J   5f   #   ?? 5g   "   $??5,0,0,0q?5h   %     gridDeleteButton#??[ 5j   %   ??5i   %   ?? *DeleteCommand+y?5k   %   ?? *	IsAdmin+# [ .??5l   &     $ Delete=?6<   #??[
 6J   5m   #   5n      5o      5q      5s      5t      5u      