# WindowsNotify

## ����

### ����

## ʹ�÷���

��ʹ�ã�

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg"
```

�޸ĵ�������ʱ�䣨Ĭ��5�룩

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg" -duration 10
```

�޸���ɫ

����`-light`���ɣ�Ĭ����ɫ��

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg" -light
```

## ʹ���Զ���ģ��

���õ�ģ��ֻ֧����Ϣ��������ͨ�ı�����ʽ���֣������Ҫ������Ի�����ʽ������ʹ���Զ���ģ��

ʹ�÷�����

### 1. ��WindowsNotify.exeͬ���½�`template`�ļ���

### 2. �½�ģ���ļ���������ʽΪ`{{template}}.html`�����������html��ǩ��body���֣�������body��ǩ��

������ģ������Ϊ`my_template`Ϊ�����½���html�ļ�����Ϊ`my_template.html`

��������д��������

``` html
<ul>
	<li>1. {first_param}</li>
	<li>2. {second_param}</li>
	<li>3. {third_param}</li>
</ul>
```

WindowsNotify�Ჹȫ����html��չʾ�ڵ����С�

``` sh
.\WindowsNotify.exe -title "title" -template my_template -first_param aaa -second_param bbb -third_param ccc
```

