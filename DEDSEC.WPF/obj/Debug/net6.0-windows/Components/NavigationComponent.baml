   M S B A M L   `   `   `  ????  
DEDSEC.WPF/    )DEDSEC.WPF.Components.NavigationComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Aav2http://schemas.microsoft.com/expression/blend/2008     5      c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5        ? 	Resources  5	       ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? Padding ?? Triggers P? Property P? Value??%  '??       ?? 5
   
   " ??6   .?5      ??  ? ??
 ???? 6+   ?? 5       ? ??
 ??+??6+   ?? 5       ? ??$ 0q?60   ?? 5       ?@?Cursor$
 Hand??6'   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? $ 10q?6$   #??z??61   5      5       5      P? 5       ?@J?IsMouseOver$
 True??61   . ?5      ??  ? ?? 5      ?? 5      " ??6.   .R?5   "   ?? $ 10q?6,   #??z??69   5      5      5      5!      5"      .??5#      ? 	 ? RowDefinitions	 5$   
   ?? 5%      $??* ?6   ?? 5&      $
??auto ?6   .+?5)   
   ?? $??1??5*      $	??580??5+      
 ?? Padding$
 0,0,0,24q?5,         ColorPrimary#??[  5-       ?? CornerRadius$ 	0 50 0 30??5.      ._?5/      ]? .+?51      ?? $??80??52      $??80??53      $??
20,-30,0,0q?54      $
 3q?55      $
??Left=?56      
???????$	 100??58      $	??Top=?59      ._?5:      A? ??5;      ?? 5<       ?? ImageSource$ /Components/ic_person.png??6)   5>      5?      ?? 5A      $??4,24,0,8q?5B      $	??Top=?5C      $??22(?5D      $??SemiBold"?5E      
???????$??Dedsec club??5G       ?? TextAlignment$ Center=?5H      ?? 5J      $	??Top=?5K      $??14(?5L      $??SemiBold"?5M      ???#d0bfff$ Center=?5O      ?? 6-   .F?5P      ??  ?? Orientation$ 
Horizontal=?6%   .+?5Q      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Star=?5R   !     	adminIcon#??[ 5S   !   y?5T   !   ?? *	IsAdmin+   BooleanToVisibilityConverter ?? 	Converter# [ ?? 5U      ??6(   ?? *
Nickname+5V      5W      6+   ?? 5Z      $	??0.8??5[      $??24q?5\        ColorSeparatorSecond#??[ 5]      $	??Top=?5^      ?? 5a      $	??Top=?6   .+?5b      ??   
menuButton#??[ 5d      ??5c      ?? *NavigateAccountCommand+y?5e      ?? *
IsLoggedIn+# [ .??5f      ?? $ 
Horizontal=?6%   .+?5g        $ Account=?64     menuButtonIcon#??[ 6C   ?? 5h      $??Аккаунт??6(   5i      5j      ?? 5l      #??[ 5n      ??5m      ?? *NavigateGameListingCommand+y?5o      ?? *
IsLoggedIn+# [ .??5p      ?? $ 
Horizontal=?6%   .+?5q        $ NintendoGameBoy=?64   #??[ 6K   ?? 5r      $??Игры??6(   5s      5t      ?? 5v      #??[ 5x      ??5w      ?? *NavigateMeetingListingCommand+y?5y      ?? *
IsLoggedIn+# [ .??5z      ?? $ 
Horizontal=?6%   .+?5{        $ Calendar=?64   #??[ 6D   ?? 5|      $??Встречи??6(   5}      5~      ?? 5?      #??[ 5?      ??5?      ?? *NavigatePlayerListingCommand+y?5?      ?? *
IsLoggedIn+# [ .??5?      ?? $ 
Horizontal=?6%   .+?5?        $ AccountMultipleOutline=?64   #??[ 6R   ?? 5?      $??Игроки??6(   5?      5?      5?      ?? 5?      $??Bottom=?5?      $??Bottom=?5?      #??[ 5?      ??5?      ?? *NavigateLoginCommand+y?5?      ?? *
IsUnlogged+# [ .??5?      ?? $ 
Horizontal=?6!   .+?5?        $ Login=?60   #??[ 6=   ?? 5?      $??
Войти??6$   5?      5?      ?? 5?      $??Bottom=?5?      $??Bottom=?5?      #??[ 5?      ??5?      ?? *LogoutCommand+y?5?      ?? *
IsLoggedIn+# [ .??5?      ?? $ 
Horizontal=?6!   .+?5?        $ Logout=?60   #??[ 6>   ?? 5?      $??
Выйти??6$   5?      5?      5?      5?      5?      5?      