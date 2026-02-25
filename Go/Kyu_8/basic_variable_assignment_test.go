package kata_test

import (
	. "codewars/Kyu_8"

	. "github.com/onsi/ginkgo/v2"
	. "github.com/onsi/gomega"
)

var _ = Describe("Test Example", func() {
	It("should test that the solution returns the correct value", func() {
		Expect(Namevar()).To(Equal("codewa.rs"))
	})
})
