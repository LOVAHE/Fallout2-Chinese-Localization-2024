Sub ������ת��()  '�˴���Ϊָ���ļ���������ѡȡ��WORD�ļ��Ľ��и�ʽ����
    'On Error Resume Next'���Դ���
    '����һ���ļ���ѡȡ�Ի���
    Set MyDialog = Application.FileDialog(msoFileDialogFilePicker)
    With MyDialog
        .Title = "��ѡ��Ҫ������ĵ����ɶ�ѡ��"
        .Filters.Clear    '��������ļ�ɸѡ���е���Ŀ
        .Filters.Add "���� WORD �ļ�", "*.MSG", 1    '����ɸѡ������ĿΪ����WORD�ļ�
        .AllowMultiSelect = True    '�������ѡ��
        If .Show = -1 Then    'ȷ��
            Application.ScreenUpdating = False
            For Each vrtSelectedItem In .SelectedItems    '������ѡȡ��Ŀ��ѭ��
                Set Doc = Documents.Open(FileName:=vrtSelectedItem, Visible:=True)
                Selection.Range.TCSCConverter WdTCSCConverterDirection:= _
                    wdTCSCConverterDirectionTCSC, CommonTerms:=True, UseVariants:=False
                Doc.Save
                Doc.Close
            Next
            Application.ScreenUpdating = True
        End If
    End With
    MsgBox "�����������!", vbInformation
End Sub
