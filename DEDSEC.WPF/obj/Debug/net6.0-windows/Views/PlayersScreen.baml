   M S B A M L   `   `   `  ????  
DEDSEC.WPF$    DEDSEC.WPF.Views.PlayersScreen   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?   ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5	      $
??auto ?6   ?? 5
      $??* ?6   .+?5   
   ?? $??0??5      $??0,20,0,0q?5         textBlockTitle#??[  5      $??Игроки??5      ?? 5   
   $??0??5        optionButton#??[ 5      ??5      ?? *AddPlayerCommand+y?5      ?? *IsCurrentAccountAdmin+   BooleanToVisibilityConverter ?? 	Converter# [ .??5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=?6(     optionButtonIcon#??[ 64   ?? 5      $??0,0,8,0q?6   $0??*Добавить нового игрока??6-   5      5      ?? 5!   
   $??1??5"      $??	0,20,0,10q?5#      $
??Left=?5$      $??Center=?5%      $??18(?5&      $??SemiBold"?5'        ColorTextForeground#??[ 5(      ??5)      ?? *PlayerViewModelsCountDisplay+ ?? UpdateSourceTrigger$ PropertyChanged=?&   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ PlayersDataGrid??5-      $??2??5.        DataGridCellStyle1   	CellStyle# ?  5/        DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  50        DataGridRowStyle1   RowStyle# ?  52        DataGridStyle1#???  53      ??51      ?? *PlayerViewModels+	   Columns	 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 56         CanUserResize$ False??58         Header$ Никнейм??59         
IsReadOnly$
 True??5:      1  +System.Windows.Controls.DataGridBoundColumn   Binding 57      ?? *
Nickname+5:        5;      $
 * 5<      $ False??5>      $ Имя??5?      $
 True??5@       5=      ?? *Name+5@        5A      $

 auto 5B      $ False??5D      $ Возраст??5E      $
 True??5F       5C      ?? *Age+5F        5G      $
 * 5H      $ False??5J      $ Обо мне??5K      $
 True??5L       5I      ?? *	AboutMe+5L        5M      $

 auto 5N      $ False??5P      $ Посещено??5Q      $
 True??5R       5O      ?? *	IsVisited+ ?? Mode$ OneWay=? 	 YesOrNotConverter# [	 5R        5S      $

 auto 5T      $ False??5V      $ 
Админ??5W      $
 True??5X       5U      ?? *	IsAdmin+$ OneWay=?# [	 5X      4  .System.Windows.Controls.DataGridTemplateColumn  5Y      $
 * 5Z      $ False??5[      $ Действия??5\      $
 True??5]         CellTemplate 5^      ?? 5_      .R?5`      ?? $ 
Horizontal=?6)   .+?5a   "   ??  
 gridShowButton#??[
 6I   ??6)   ?? *ShowCommand+.??5b   &     $ Magnify=?6<     gridButtonIcon#??[ 6K   5c   #   ?? 5d   "   $??5,0,0,0q?5e   %     gridEditButton#??[ 5g   %   ??5f   %   ?? *EditCommand+y?5h   %   ?? *IsCurrentAccountAdmin+# [ .??5i   &     $ AccountEdit=?6<   #??[ 6O   5j   #   ?? 5k   "   $??5,0,0,0q?5l   %     gridDeleteButton#??[ 5n   %   ??5m   %   ?? *DeleteCommand+y?5o   %   ?? *IsCurrentAccountAdmin+# [ .??5p   &     $ Delete=?6<   #??[ 6J   5q   #   5r      5s      5u      5w      5x      5y      