# HongGuang-Network #

一款开源、免费的校园网断网后上网工具。

**声明**：软件仅用于学习与交流，对于任何由非法使用本软件造成的问题本人概不负责。

# 特色 #

- 小巧轻便，文件加起来不够300KB。

- 开源项目，公开源代码，用着放心。

- 完全免费，没有广告。

# 原理 #

利用上网系统注销后那一瞬间是可以上网的时间，不断向服务器POST请求。

例如说你要把门关上，那我就不断地请求把门打开，所以说即便如此，在使用过程中可能还是会遇到断流问题。

所以**不建议**使用本软件玩游戏！

另外由于本软件的原理是不断向服务器推送GET请求，所以不用的时候请关闭本软件，不然耗费系统资源(虽然我不觉得能耗多少，但是一直死循环向服务器发送消息总是吃性能的)。

不过讲道理，程序我是写出来了，效果真的不咋地。。看着看着网页突然一个断网策略就弹出来了，还不能刷新和后退。。

另外这个学期以后学校网管应该是有所察觉，把logout页面拿掉了，所以这个程序也失效了，我也不会再更新，应该。

所以有条件的开热点吧。。真心的。。

# 更新历史 #

2017年7月7日：

- 用Thread重写，收放自如

2016年12月14日：

- 重构并优化代码，源码看起来更顺眼更有条理
- 新增一个自动模式，不用自己设置频率了
- 也许是最终版？

2016年12月14日：

- 第一版本
