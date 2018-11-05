Imports ThalesSim.Core.Cryptography
Imports ThalesSim.Core.Message
Imports ThalesSim.Core.PIN.PINBlockFormat

Namespace HostCommands.BuildIn

    <ThalesCommandCode("M0", "M1", "", "Encrypt a block of data.")>
    Public Class MessageEncrypt_M0
        Inherits AHostCommand

        Private _modeFlag As String
        Private _inputFormatFlag As String
        Private _outputFormatFlag As String
        Private _keyType As String
        Private _zek As String
        Private _messageLenght As String
        Private _message As String


        Public Sub New()
            ReadXMLDefinitions()
        End Sub

        Public Overrides Sub AcceptMessage(ByVal msg As Message.Message)
            XML.MessageParser.Parse(msg, XMLMessageFields, kvp, XMLParseResult)
            If XMLParseResult = ErrorCodes.ER_00_NO_ERROR Then

                _modeFlag = kvp.Item("Mode Flag")
                _inputFormatFlag = kvp.Item("Input Format Flag")
                _outputFormatFlag = kvp.Item("Output Format Flag")
                _keyType = kvp.Item("Key Type")
                _zek = kvp.ItemCombination("ZEK Scheme", "ZEK")
                _messageLenght = kvp.Item("Message Lenght")
                _message = kvp.Item("Message")

            End If
        End Sub

        Public Overrides Function ConstructResponse() As Message.MessageResponse
            Dim mr As New MessageResponse

            Dim cryptZEK As New HexKey(_zek)
            Dim clearZEK As String = Utility.DecryptUnderLMK(cryptZEK.ToString, cryptZEK.Scheme, LMKPairs.LMKPair.Pair30_31, "0")

            If Utility.IsParityOK(clearZEK, Utility.ParityCheck.OddParity) = False Then
                mr.AddElement(ErrorCodes.ER_10_SOURCE_KEY_PARITY_ERROR)
                Return mr
            End If


            Log.Logger.MinorInfo("Clear ZEK: " + clearZEK)
            Log.Logger.MinorInfo("Crypt ZEK: " + _zek)
            Log.Logger.MinorInfo("Message Clear:" + _message)

            Dim msgEncrypt As String = TripleDES.TripleDESEncrypt(cryptZEK, _message)

            Log.Logger.MinorInfo("Message Encrypt:" + msgEncrypt)

            mr.AddElement(ErrorCodes.ER_00_NO_ERROR)
            mr.AddElement(msgEncrypt.Length.ToString("0000"))
            mr.AddElement(msgEncrypt + msgEncrypt)

            Return mr


        End Function


    End Class


End Namespace
