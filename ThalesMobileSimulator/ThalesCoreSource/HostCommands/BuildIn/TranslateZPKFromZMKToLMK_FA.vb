''
'' This program is free software; you can redistribute it and/or modify
'' it under the terms of the GNU General Public License as published by
'' the Free Software Foundation; either version 2 of the License, or
'' (at your option) any later version.
''
'' This program is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU General Public License for more details.
''
'' You should have received a copy of the GNU General Public License
'' along with this program; if not, write to the Free Software
'' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'' 

Imports ThalesSim.Core.Message
Imports ThalesSim.Core.Cryptography
Imports ThalesSim.Core

Namespace HostCommands.BuildIn

    ''' <summary>
    ''' Translates a ZPK from encryption under a ZMK to encryption under LMK.
    ''' </summary>
    ''' <remarks>
    ''' This class implements the FA Racal command.
    ''' </remarks>
    <ThalesCommandCode("FA", "FB", "", "Translates a ZPK from encryption under a ZMK to encryption under LMK")> _
    Public Class TranslateZPKFromZMKToLMK_FA
        Inherits TranslateFromKeyToLMK

        ''' <summary>
        ''' Initialization method.
        ''' </summary>
        ''' <remarks>
        ''' Command-specific implementation of message parsers, source/target LMK pairs, 
        ''' print strings, authorized and parity flags.
        ''' </remarks>
        Public Overrides Sub InitFields()
            SourceLMK = LMKPairs.LMKPair.Pair04_05
            TargetLMK = LMKPairs.LMKPair.Pair06_07
            str1 = "ZMK (clear): "
            str2 = "ZPK (clear): "
            str3 = "Key (LMK): "
            AllowBadParity = True
        End Sub
    End Class

End Namespace
