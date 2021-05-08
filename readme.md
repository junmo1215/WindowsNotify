# WindowsNotify

## ����

### ����

.net core 3.1 Runtime

windows��װ������

<https://dotnet.microsoft.com/download/dotnet/3.1>

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

��ģ���п���ʹ���Զ�����������������{first_param}/{second_param}/{third_param}��ռλ����ռλ��ʹ�ô�����`{}`��������������Ҫ�ڵ���������ָ����Щ������ֵ��

����ʾ�����������ĵ���Ч����

![1](./imgs/1.png)

### 3. ʹ�ô��г����ӣ�< a >��ǩ����ģ��

������ģ������Ϊ`my_template_with_url`Ϊ�����½���html�ļ�����Ϊ`my_template_with_url.html`

��������д��������

``` html
<p>search in baidu: <a href="https://www.baidu.com/s?wd={query}">{query}</a></p>
```

ʹ�ã�

``` sh
.\WindowsNotify.exe -title "template with url" -template my_template_with_url -query test
```

Ч����

![2](./imgs/2.png)

�����������Ӻ󣬻���**ϵͳĬ�������**�д򿪰ٶ�����query�е����ݡ�

## ע������

1. ��Ȼ�������ݿ����Զ��壬��������ֻ������ʾ���ã����������ݹ����������Ҫ��ϸע��������ʹ�ô������ӵĵ���
2. �����Դ�����������ʵ��һ��WPF��WebBrowser�ؼ����ں���IE���������������ģ����д���ӵ����ݣ����ܻ�������ʽ�������JavaScript��������������⡣
3. ����Ŀǰֻ֧�̶ֹ�λ�ã����½ǣ�������ͬʱ�ж������������ڵ������⡣
