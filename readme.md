# WindowsNotify

## 介绍

### 依赖

## 使用方法

简单使用：

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg"
```

修改弹窗持续时间（默认5秒）

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg" -duration 10
```

修改颜色

带上`-light`即可，默认深色调

``` sh
.\WindowsNotify.exe -title "title" -msg "a notify msg" -light
```

## 使用自定义模板

内置的模板只支持消息正文以普通文本的形式呈现，如果需要满足个性化的样式，可以使用自定义模板

使用方法：

### 1. 在WindowsNotify.exe同级新建`template`文件夹

### 2. 新建模板文件，命名格式为`{{template}}.html`，在里面填充html标签的body部分（不包含body标签）

这里以模板名称为`my_template`为例，新建的html文件名称为`my_template.html`

在里面填写如下内容

``` html
<ul>
	<li>1. {first_param}</li>
	<li>2. {second_param}</li>
	<li>3. {third_param}</li>
</ul>
```

WindowsNotify会补全整个html并展示在弹窗中。

``` sh
.\WindowsNotify.exe -title "title" -template my_template -first_param aaa -second_param bbb -third_param ccc
```

