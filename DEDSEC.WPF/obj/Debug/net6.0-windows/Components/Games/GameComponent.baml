   M S B A M L   `   `   `  ????E  ADEDSEC.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DEDSEC.WPF.ExtensionsDEDSEC.WPF.Extensions  5      /    )DEDSEC.WPF.Components.Games.GameComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :
extensions#clr-namespace:DEDSEC.WPF.Extensions     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      .??5      ?? $	??200??5   	   $	??500??5	   	   $??20q?5
   	     ?? Orientation$  Vertical=?5   	   .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $
??auto ?6#   .+?5      ?? $??0??5      $
??Left=?5         textBlockTitle#??[  5      ??5      ?? *Name+?? 5      $??1??5      $??20,0,0,0q?5      $??Right=?5        optionButton#??[ 5      ??5      ?? *CloseCommand+.??5      ?? $  
Horizontal=?6   .+?5      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=?6,     optionButtonIcon#??[ 69   ?? 5      $??0,0,8,0q?6    $??Закрыть??61   5      5       5!      ?? 5"   
   $??0,20,0,0q?6   $  
Horizontal=?6'   .+?5#      ?? $	??200??5$        textBlockItemTitle#??[ 5%      $??Описание??5&      ?? 5'      $
??10,0q?5(        textBlockItemDesc#??[ 5)      ??5*      ?? *Description+5+      ?? 5-   
   ?? 5/   
   $  
Horizontal=?6   .+?50      ?? $	??200??51      #??[ 52      $)??#Количество игроков??53      ?? 54      $
??10,0q?55      #??[ 56      ??57      ?? *PlayersCount+58      ?? 59   
   ?? 5:   
   $  
Horizontal=?6   .+?5;      ?? $	??200??5<      #??[ 5=      $??Ссылка??5>      ?? 5?      $
??10,0q?6     textBlockLink#??[ 6&   ?? 5@      /   )DEDSEC.WPF.Extensions.HyperlinkExtensions   
IsExternal$
 true??6   ??6M   ?? *LinkHobbyGames+.?6t   
HobbyGames5B      5C      5D      5E      5F      