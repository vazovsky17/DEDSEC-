   M S B A M L   `   `   `  ????  
DEDSEC.WPF3    -DEDSEC.WPF.Components.Players.PlayerComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?? $	??200??5   	   $	??500??5   	   $??20q?5	   	     ?? Orientation$  Vertical=?5
   	   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $
??auto ?6#   .+?5      ?? $??0??5         textBlockTitle#??[  5      ??5      ?? *
Nickname+?? 5      $??1??5      $??20,0,0,0q?5        optionButton#??[ 5      ??5      ?? *CloseCommand+.??5      ?? $  
Horizontal=?6   .+?5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=?6,     optionButtonIcon#??[ 69   ?? 5      $??0,0,8,0q?6    $??Закрыть??61   5      5      5      ?? 5    
   ?? 5!   
   $  
Horizontal=?6   .+?5"      ?? $	??150??5#        textBlockItemTitle#??[ 5$      $??Имя??5%      ?? 5&      $
??10,0q?5'        textBlockItemDesc#??[ 5(      ??5)      ?? *Name+5*      ?? 5,   
   ?? 5.   
   $  
Horizontal=?6   .+?5/      ?? $	??150??50      #??[ 51      $??Возраст??52      ?? 53      $
??10,0q?54      #??[ 55      ??56      ?? *Age+57      ?? 58   
   ?? 59   
   $  
Horizontal=?6   .+?5:      ?? $	??150??5;      #??[ 5<      $??Обо мне??5=      ?? 5>      $
??10,0q?5?      #??[ 5@      ??5A      ?? *	AboutMe+5B      ?? 5C   
   ?? 5D   
   $  
Horizontal=?6   .+?5E      ?? $	??150??5F      #??[ 5G      $$??Присутствовал(а)??5H      ?? 5I      $
??10,0q?5J      #??[ 5K      ??5L      ?? *	IsVisited+  YesOrNotConverter ?? 	Converter# [ 5M      5N      5O      