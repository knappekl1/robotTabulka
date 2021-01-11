Public Class Form1
    Dim Table1 As DataTable = New DataTable()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Ahoj, já jsem robot Bela v počítači a vypočítám za tebe domácí úkol z matematiky na straně 40")
        'Create table with n columns
        Dim tableSize As Int16 = 5
        Dim startNumber As Int32 = 0
        Dim stepNumber As Int32 = 1
        ' Create columns in table
        For i As Integer = 0 To tableSize - 1
            Table1.Columns.Add(Chr(65 + i), GetType(System.Int32))
        Next

        'Populate and add rows to table
        'Add rows
        For j As Integer = 0 To tableSize - 1
            Dim row As DataRow = Table1.NewRow()
            Dim values As New List(Of Int32)
            For i As Integer = 0 To tableSize - 1
                Dim value As Integer = startNumber + i * stepNumber
                row(i) = value
                values.Add(value)
            Next
            startNumber = values.LastOrDefault() + stepNumber
            Table1.Rows.Add(row)
        Next

        'Show in datagrid
        dgvTable1.DataSource = Table1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Int16
        Dim test As Date = #2020/02/23 2:30 PM#
        Dim result1 As List(Of Int32) = New List(Of Integer)
        Dim result2 As List(Of Int32) = New List(Of Integer)
        If Not Int16.TryParse(tbInput.Text, count) Then
            MessageBox.Show("Zadej číslo od 1 do 5")
            Return
        ElseIf tbInput.Text = 0 Or tbInput.Text > 5 Then
            MessageBox.Show("Zadej číslo od 1 do 5")
            Return
        Else
            count = tbInput.Text - 1
        End If
        'Sum columns
        For k As Integer = 0 To Table1.Rows.Count - 1
            For i As Integer = 0 To (4 - count)
                Dim suma1 As Int32 = 0
                Dim suma2 As Int32 = 0
                For j As Integer = i To i + count
                    suma1 += Table1.Rows(k).Item(j)
                    suma2 += Table1.Rows(j).Item(k)
                Next
                result1.Add(suma1)
                result2.Add(suma2)
            Next
        Next
        'Sum rows
        tbOutput.Text = "Vedle sebe: " & String.Join(", ", result1) & vbCrLf & "Pod sebou: " & String.Join(", ", result2)
    End Sub
End Class
