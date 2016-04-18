Option Explicit On
Imports Microsoft.SPOT
Imports Microsoft.SPOT.Hardware
Imports SecretLabs.NETMF.Hardware
Imports SecretLabs.NETMF.Hardware.NetduinoPlus
Imports Toolbox.NETMF.Hardware
Imports System.Threading
Imports SecretLabs.NETMF.IO

Module GoPro_TimeLapse
    
    

    Sub Main()
        Dim RTC As DS1307 = New DS1307()
        Dim TimeSecond As Double = DateTime.Now.Second
        Dim TimeHour As Double
        'Dim led = New OutputPort(Pins.ONBOARD_LED, False)
        'Dim CamRelay = New OutputPort(Pins.GPIO_PIN_D5, False)
        'Dim ShieldLED1 = New OutputPort(Pins.GPIO_PIN_D3, False)


        RTC.SetTime(Year:=2016, Month:=4, Day:=18, Hour:=22, Minute:=30, Second:=0) 'time set to current time. set once at initial install then commented.
        RTC.Synchronize()
        Debug.Print(DateTime.Now.ToString())
        Do While True
            Photo()
            TimeHour = DateTime.Now.Hour
            Select Case TimeHour
                Case 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 22, 23, 0
                    If DateTime.Now.Minute = 0 OrElse DateTime.Now.Minute = 15 OrElse DateTime.Now.Minute = 30 OrElse DateTime.Now.Minute = 45 Then
                        If DateTime.Now.Second <> 0 OrElse DateTime.Now.Second <> 1 OrElse DateTime.Now.Second <> 2 OrElse DateTime.Now.Second <> 3 _
                        OrElse DateTime.Now.Second <> 4 OrElse DateTime.Now.Second <> 5 Then

                        Else
                            Photo()
                        End If

                    End If
            End Select
        Loop


        ' If DateTime.Now.Hour = 23 Then
        'Debug.Print(DateTime.Now.ToString())
        'End If

    End Sub
    Private Sub Photo()
        Dim RTC As DS1307 = New DS1307()
        Dim TimeSecond As Double = DateTime.Now.Second
        Dim led = New OutputPort(Pins.ONBOARD_LED, False)
        Dim CamRelay = New OutputPort(Pins.GPIO_PIN_D5, False)
        Dim PhotoCount As Integer = 0
        Dim lastphoto As String


        led.Write(True)
        CamRelay.Write(True)
        Thread.Sleep(3000)
        CamRelay.Write(False)
        Thread.Sleep(15000)
        CamRelay.Write(True)
        Thread.Sleep(4000)
        CamRelay.Write(False)
        led.Write(False)
        PhotoCount = PhotoCount + 1
        lastphoto = DateTime.Now.ToString()
        Debug.Print("The Photo Count is: " & PhotoCount)
        Debug.Print(lastphoto)

    End Sub

    Private Sub NoPhoto()
        Dim ShieldLED1 = New OutputPort(Pins.GPIO_PIN_D3, False)
        For A = 1 To 10
            ShieldLED1.Write(True)
            Thread.Sleep(500)
            ShieldLED1.Write(False)
            Thread.Sleep(500)
        Next


    End Sub

End Module
