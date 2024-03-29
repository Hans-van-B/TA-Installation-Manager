@call %~dp0Init
TITLE Create Local Depo Share

:CREATESHARE
if exist \\%COMPUTERNAME%\%SHARENAME% goto MAPDRIVE

if not exist "%SHARE_DIR%" md "%SHARE_DIR%"
if not exist "%SHARE_DIR%\TA_InstLib" (
    md "%SHARE_DIR%\TA_InstLib\04\Inst\bat"
    md "%SHARE_DIR%\TA_InstLib\04\Inst\data"
    md "%SHARE_DIR%\TA_InstLib\04\Inst\exe"
    )


NET LOCALGROUP TA_DEPO_Admin /ADD /COMMENT:"Provides Admin access to the TA Inst Depo"
NET LOCALGROUP TA_DEPO_Install /ADD /COMMENT:"Provides Read access to the TA Inst Depo for users that need to install software"

NET LOCALGROUP TA_DEPO_Admin Administrators /ADD
NET LOCALGROUP TA_DEPO_Admin %USERNAME% /ADD
NET LOCALGROUP TA_DEPO_Install %USERNAME% /ADD

NET SHARE %SHARENAME%="%SHARE_DIR%" /GRANT:TA_DEPO_Admin,FULL /GRANT:TA_DEPO_Install,READ /REMARK:"Technical Application Installation Share"

:MAPDRIVE
NET USE %DEPODRV% \\%COMPUTERNAME%\%SHARENAME% /PERSISTENT:YES

echo Finished
timeout /t 4
