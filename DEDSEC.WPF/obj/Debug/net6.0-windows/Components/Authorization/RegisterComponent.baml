   M S B A M L   `   `   `  ????E  ADEDSEC.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DEDSEC.WPF.Components.CommonDEDSEC.WPF.Components.Common  5      ;    5DEDSEC.WPF.Components.Authorization.RegisterComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =common*clr-namespace:DEDSEC.WPF.Components.Common     5      .??5      ? $	??200??5   	   $
??1000??5   	   $??20q?5	   	     ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   .+?5   
   ?? $??0??5      $??Center=?5      $??28(?5         ColorTextForeground#??[  5      $*??$Зарегистрироваться??5      ?? 5   
   $??1??6   $??20q?6"   .+?5      ?? $??2??5      $??Center=?5      $.??(Уже зарегистрированы???5       $??11(?5!        borderlessButton#??[ 5"      ??5      ?? *NavigateLoginCommand+5"      ? 5#      $	??140??6   .+?5$      ?? $
??15,0q?5%      $??Center=?5&       K? ZIndex$ 1??5'        ColorTextBoxHint#??[ 5(       J? IsHitTestVisible$ False??5)      $??Никнейм??5*      y?5+      ??  ?? ElementName$ textBoxNickname?? ?? Path$ Text.IsEmpty?   BooleanToVisibilityConverter ?? 	Converter# [ ?? 5,      -   5         ??Name$ textBoxNickname??5-        textBoxDefault#??[ 5.      ??5/      ?? *
Nickname+ ?? UpdateSourceTrigger$ PropertyChanged=?50      ? 51      $	??140??6   $??0,10,0,0q?6"   .+?52      ?? $
??15,0q?53      $??Center=?54      $ 1??55      #??[ 56      $ False??57      $??Пароль??58      y?59      ?? $ textBoxPassword??$ Password.IsEmpty?# [ 6   0DEDSEC.WPF.Components.Common.BindablePasswordBox  5:      -   5        	  Name$	 textBoxPassword??5:   -   
   Password
 6F   ?? *
Password+$ PropertyChanged=?5;      ? 5<      $	??140??6   $??0,10,0,0q?6"   .+?5=      ?? $
??15,0q?5>      $??Center=?5?      $ 1??5@      #??[ 5A      $ False??5B      $-??'Подтверждение пароля??5C      y?5D      ?? $ textBoxConfirmPassword??$ Password.IsEmpty?# [   5E      -   5        $	 textBoxConfirmPassword??5E   -   
 6M   ?? *ConfirmPassword+$ PropertyChanged=?5F      ?? 5H      $??3??5I      $??0,10,0,0q?5J      $??Center=?5K       ?? Orientation$ 
Horizontal=?5L      .+?5M      ?? $??11(?5N      #??[  5O      $ ??Администратор??5P      ?? 5Q      $??5,0,0,0q?5R        CornerCheckBoxStyle#??[ 5T       d? 	IsChecked 5S      ?? *	IsAdmin+5T      5U      ? 5V      $	??140??5W      $??0,10,0,0q?5X      y?5Y      ?? *	IsAdmin+# [ .+?5Z      ?? $
??15,0q?5[      $??Center=?5\      $ 1??5]      #??[ 5^      $ False??5_      $'??!Код администрации??5`      y?5a      ?? $ textBoxAdministrationCode??$ Password.IsEmpty?# [   5b      -   5        $	 textBoxAdministrationCode??5b   -   
 6P   ?? *AdministrationCode+$ PropertyChanged=?5c      5d      ?? 5f   
   $??2??5g      $??Center=?5h      $??Продолжить??5j      #??[ 5k      ??5i      ?? *RegisterCommand+5k      ?? 5m   
   $??3??5n      $??0,10,0,0q?5o      $??Center=?5p      
???  ?? ? DataContext 5q      ?? *ErrorMessageViewModel+??5s      ?? *	Message+y?5t      ?? *
HasMessage+# [ 5u      5v      