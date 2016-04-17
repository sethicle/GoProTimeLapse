Imports Microsoft.SPOT
Imports Microsoft.SPOT.Hardware
Imports SecretLabs.NETMF.Hardware
Imports SecretLabs.NETMF.Hardware.Netduino
Imports Toolbox.NETMF.Hardware
Imports System.Threading
Imports SecretLabs.NETMF.IO
Imports System.IO

Module GoPro_TimeLapse
    


    Sub Main()
        Dim RTC As DS1307 = New DS1307()
        Dim TimeHour As Double
        Dim TimeSecond As Double = DateTime.Now.Second
        Dim led = New OutputPort(Pins.ONBOARD_LED, False)
        Dim CamRelay = New OutputPort(Pins.GPIO_PIN_D5, False)

        RTC.SetTime(Year:=2016, Month:=4, Day:=13, Hour:=23, Minute:=6, Second:=30) 'time set to current time. set once at initial install then commented.
        RTC.Synchronize()

        While (True)
            TimeHour = DateTime.Now.Minute
            Select Case TimeHour
                Case 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 23, 24
                    If DateTime.Now.Minute = 0 OrElse DateTime.Now.Minute = 15 OrElse DateTime.Now.Minute = 30 OrElse DateTime.Now.Minute = 45 Then
                        If DateTime.Now.Second <> 0 OrElse DateTime.Now.Second <> 1 OrElse DateTime.Now.Second <> 2 OrElse DateTime.Now.Second <> 3 _
                        OrElse DateTime.Now.Second <> 4 OrElse DateTime.Now.Second <> 5 Then

                        Else
                            Photo()
                        End If

                    End If
            End Select
        End While


        ' If DateTime.Now.Hour = 23 Then
        'Debug.Print(DateTime.Now.ToString())
        'End If

    End Sub
    Sub Photo()
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

End Module
