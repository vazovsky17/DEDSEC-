   M S B A M L   `   `   `  ????E  ADEDSEC.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DEDSEC.WPF.Components.CommonDEDSEC.WPF.Components.Common  5      8    2DEDSEC.WPF.Components.Authorization.LoginComponent   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      =common*clr-namespace:DEDSEC.WPF.Components.Common     5      .??5      ? $	??200??5   	   $
??1000??5   	   $??20q?5	   	     ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   .+?5   
   ?? $??0??5      $??Center=?5      $??28(?5         ColorTextForeground#??[  5      $??
Войти??5      ?? 5   
   $??1??6   $??20q?6"   .+?5      ?? $??2??5      $??Center=?5      $3??-Еще не зарегистрированы???5       $??11(?5!        borderlessButton#??[ 5"      ??5      ?? *NavigateRegisterCommand+5"      ? 5#      $	??140??6   .+?5$      ?? $
??15,0q?5%      $??Center=?5&       K? ZIndex$ 1??5'        ColorTextBoxHint#??[ 5(       J? IsHitTestVisible$ False??5)      $??Никнейм??5*      y?5+      ??  ?? ElementName$ textBoxNickname?? ?? Path$ Text.IsEmpty?   BooleanToVisibilityConverter ?? 	Converter# [ ?? 5,      -   5         ??Name$ textBoxNickname??5-        textBoxDefault#??[ 5.      ??5/      ?? *
Nickname+ ?? UpdateSourceTrigger$ PropertyChanged=?50      ? 51      $	??140??6   $??0,10,0,0q?6"   .+?52      ?? $
??15,0q?53      $??Center=?54      $ 1??55      #??[ 56      $ False??57      $??Пароль??58      y?59      ?? $ textBoxPassword??$ Password.IsEmpty?# [ 6   0DEDSEC.WPF.Components.Common.BindablePasswordBox  5:      -   5        	  Name$	 textBoxPassword??5:   -   
   Password
 6F   ?? *
Password+$ PropertyChanged=?5;      ?? 5=      $??3??5>      $??0,10,0,0q?5?      $??Center=?5@       ?? Orientation$ 
Horizontal=?5A      .+?5B      ?? $??11(?5C      #??[  5D      $ ??Администратор??5E      ?? 5F      $??5,0,0,0q?5G      $|?False??5H        CornerCheckBoxStyle#??[ 5J       d? 	IsChecked 5I      ?? *	IsAdmin+5J      5K      ? 5L      $	??140??5M      $??0,10,0,0q?5N      y?5O      ?? *	IsAdmin+# [ .+?5P      ?? $
??15,0q?5Q      $??Center=?5R      $ 1??5S      #??[ 5T      $ False??5U      $'??!Код администрации??5V      y?5W      ?? $ textBoxAdministrationCode??$ Password.IsEmpty?# [   5X      -   5        $	 textBoxAdministrationCode??5X   -   
 6P   ?? *AdministrationCode+$ PropertyChanged=?5Y      5Z      ?? 5\   
   $??2??5]      $??Center=?5^      $??Продолжить??5`       ?? 	IsDefault$
 True??5a      #??[ 5b      ??5_      ?? *LoginCommand+5b      ?? 5d   
   $??3??5e      $??0,10,0,0q?5f      $??Center=?5g      
???  ?? ? DataContext 5h      ?? *ErrorMessageViewModel+??5j      ?? *	Message+y?5k      ?? *
HasMessage+# [ 5l      5m      