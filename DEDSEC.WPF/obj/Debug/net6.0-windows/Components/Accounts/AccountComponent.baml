   M S B A M L   `   `   `  ????  
DEDSEC.WPF5    /DEDSEC.WPF.Components.Accounts.AccountComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .??5      ??   ?? Orientation$  Vertical=?6   .+?5   
   ?? $  
Horizontal=?6   .+?5      ?? $	??150??5         textBlockItemTitle#??[  5	      $??Никнейм??5
      ?? 5      $
??10,0q?5        textBlockItemDesc#??[ 5      ??5      ?? *
Nickname+5      ?? 5   
   ?? 5   
   $  
Horizontal=?6   .+?5      ?? $	??150??5      #??[  5      $??Имя??5      ?? 5      $
??10,0q?5      #??[ 5      ??5      ?? *Name+5      ?? 5   
   ?? 5   
   $  
Horizontal=?6   .+?5      ?? $	??150??5       #??[  5!      $??Возраст??5"      ?? 5#      $
??10,0q?5$      #??[ 5%      ??5&      ?? *Age+5'      ?? 5(   
   ?? 5)   
   $  
Horizontal=?6   .+?5*      ?? $	??150??5+      #??[  5,      $??Обо мне??5-      ?? 5.      $
??10,0q?5/      #??[ 50      ??51      ?? *	AboutMe+52      ?? 53   
   ?? 54   
   $  
Horizontal=?6   .+?55      ?? $	??150??56      #??[  57      $$??Присутствовал(а)??58      ?? 59      $
??10,0q?5:      #??[ 5;      ??5<      ?? *	IsVisited+  YesOrNotConverter ?? 	Converter# [ 5=      ?? 5>   
   y?6   ?? *HasFavoriteGames+ ?? UpdateSourceTrigger$ PropertyChanged=?   BooleanToVisibilityConverter# [ ?? 5?   
   $  Vertical=?6   y?6,   ?? *HasFavoriteGames+$ PropertyChanged=?# [ .+?5@      ?? $	??150??5A      $
??Left=?5B      #??[  5C      $??Любимые игры??5D      &   System.Windows.Controls.DataGrid  5F      -   5          Name$ GamesDataGrid??5G      $??	0,10,0,10q?5H        DataGridCellStyle1   	CellStyle# ?  5I        DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  5J        DataGridRowStyle1   RowStyle# ?  5L        DataGridStyle1#???  5M      ??5K      ?? *FavoriteGames+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5P      	   CanUserResize$	 False??5R      
   Header$
 Название??5S         
IsReadOnly$
 True??5T      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5Q      ?? *Name+5T        5U      $ * 5V      $	 False??5X      $
 Описание??5Y      $
 True??5Z       5W      ?? *Description+5Z      5\      5]      ?? 5^   
   y?6   ?? *HasFeatureMeetings+$ PropertyChanged=?# [ ?? 5_   
   $  Vertical=?6   y?6,   ?? *HasFeatureMeetings+$ PropertyChanged=?# [ .+?5`      ?? $	??200??5a      $
??Left=?5b      #??[  5c      $3??-Запланированные встречи??5d        5f      -   5        $ MeetingsDataGrid??5g      $??	0,10,0,10q?5h      # ?  5i      # ?  5j      # ?  5l      #???  5m      ??5k      ?? *FeatureMeetings+ 5n        5o      $ * 5p      $	 False??5r      $
 Название??5s      $
 True??5t       5q      ?? *Title+5t        5u      $ * 5v      $	 False??5x      $
 Описание??5y      $
 True??5z       5w      ?? *Description+5z        5{      $ * 5|      $	 False??5~      $
 Начало??5      $
 True??5?       5}      ?? *	DateBegin+5?      5?      5?      5?      5?      