# CustomComboCN

此插件旨在将连击和互相关联的能力技合并到一个按键上，感谢 [daemitus](https://github.com/attickdoor/XIVComboPlugin)  和 [attickdoor](https://github.com/daemitus/XIVComboPlugin) 的工作，他们实现了最初的基础功能，使得此插件的功能得以实现。
此仓库专注于降低身为国服玩家的开发维护人员的开发体验，并且使得合作开发更为简单方便。

## 开发

首先在根目录创建一个名为`sdk`的文件夹，然后将獭爹的`Dalamud.Updater`下载的运行时文件夹内的所有文件放到`sdk`目录下。
在`powershell`或`cmd`下运行`debug.bat`，你会在根目录的`build/debug`路径找到生成的dll。