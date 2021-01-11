Public Class Form1
    Dim Table1 As DataTable = New DataTable()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Ahoj, já jsem robot Bela v počítači a vypočtám za tebe domácí úkol z matematiky na straně 40")
        'Create table with n columns
        Dim tableSize As Int16 = 5
        Dim startNumber As Int32 = 0
        Dim stepNumber As Int32 = 1
        ' Create columns in table
        For i As Integer = 0 To tableSize - 1
            Table1.Columns.Add(Chr(65 + i), GetType(System.Int32))
        Next

        'Populate and add rows to table


        'Create table with 5 columns
        'Table1.Columns.Add("A", GetType(System.Int32))
        'Table1.Columns.Add("B", GetType(System.Int32))
        'Table1.Columns.Add("C", GetType(System.Int32))
        'Table1.Columns.Add("D", GetType(System.Int32))
        'Table1.Columns.Add("E", GetType(System.Int32))
        'Add rows
        Table1.Rows.Add(0, 1, 2, 3, 4)
        Table1.Rows.Add(5, 6, 7, 8, 9)
        Table1.Rows.Add(10, 11, 12, 13, 14)
        Table1.Rows.Add(15, 16, 17, 18, 19)
        Table1.Rows.Add(20, 21, 22, 23, 24)

        'Show in datagrid
        dgvTable1.DataSource = Table1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim count As Int16

        Dim result As List(Of Int32) = New List(Of Integer)
        If Not Int16.TryParse(tbInput.Text, count) Then
            MessageBox.Show("Zadej číslo od 1 do 5")
            Return
        ElseIf tbInput.Text = 0 Or tbInput.Text > 5 Then
            MessageBox.Show("Zadej číslo od 1 do 5")
            Return
        Else
            count = tbInput.Text - 1
        End If

        For k As Integer = 0 To Table1.Rows.Count - 1
            For i As Integer = 0 To (4 - count)
                Dim suma As Int32 = 0
                For j As Integer = i To i + count
                    suma += Table1.Rows(k).Item(j)
                Next
                result.Add(suma)
            Next
        Next
        tbOutput.Text = String.Join(", ", result)
    End Sub
End Class
