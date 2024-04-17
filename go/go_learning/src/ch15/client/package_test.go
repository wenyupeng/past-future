package client

//import (
//	"ch15/series"
//	"testing"
//)
//
//func TestPackage(t *testing.T) {
//	t.Log(series.GetFibonacciSeries(5))
//}

// 这个例子需要查看GO111MODULE是否打开 （go env）如显示set GO111MODULE=on，则需要关闭setting中的 enable go module integration
// 先把项目添加到GO_PATH，然后关闭 GO111MODULE
// GOPATH 模式（GO111MODULE=off）：Go 命令行工具从不使用 Go Modules。相反，它查找 vendor 目录和 GOPATH 以查找依赖项。
// Go Modules 模式（GO111MODULE=on）：Go 命令行工具只使用 Go Modules，从不咨询 GOPATH。GOPATH 不再作为导入目录，但它仍然存储下载的依赖项（GOPATH/pkg/mod/）和已安装的命令（GOPATH/bin/），只移除了 GOPATH/src/。
