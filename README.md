# textparse
A Text format conversion tool
xmlparse
这是一个用于语言格式转换的工具。你可以用一个模板文件一个取值匹配文件做为配置，然后选择一个你想要转换的文件进行模板转换。

如：这是一个取值匹配文件 docconfig.txt {0}，{1}。{2}撰。{3}。{4}。{5}抄本。{6}。今藏{7}。有{8}译本，收入{9}。

如：这是一个模板文件 。 
<古籍> 
  <分卷>${0}</分卷>  
  <页数>${1}</页数>  
  <作者>${2}</作者>  
  <分类>${3}</分类>  
  <内容>${4}</内容>  
  <抄本>${5}</抄本>  
  <装帧>${6}</装帧>  
  <收藏>${7}</收藏>  
  <译本>${8}</译本>  
  <出版>${9}</出版> 
</古籍>

如：这是想要转换的文件 template.xml

不分卷1册，50页。佚名撰。东巴教祭天仪式经书。记叙纳西族祖先崇忍利恩与天女，讲述了纳西族的由来及纳西族的缘由。旧抄本。 本色构皮纸，线订册叶装，墨书。页面9.2x28.6cm，外边双栏。原封面及第1、2页佚失，作过增补修复。边角有破损。今藏云南省社会社研究所 。有李例芬译本，收入《asdfasdf》第1卷，云南人民出版社1999年版。

用程序转换之后 ： 
<?xml version="1.0" encoding="utf-8"?>

<古籍> 
  <分卷>不分卷1册</分卷>  
  <页数>50页</页数>  
  <作者>佚名</作者>  
  <分类>东巴教祭天仪式经书</分类>  
  <内容>记叙纳西族祖先崇忍利恩与天女，讲述了纳西族的由来及纳西族的缘由</内容>  
  <抄本>旧</抄本>  
  <装帧>本色构皮纸，线订册叶装，墨书。页面9.2x28.6cm，外边双栏。原封面及第1、2页佚失，作过增补修复。边角有破损</装帧>  
  <收藏>云南省社会社研究所</收藏>  
  <译本>李例芬</译本>  
  <出版>《asdfasdf》第1卷，云南人民出版社1999年版</出版> 
</古籍>
