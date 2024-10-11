-- PATTERN

/*

Declare @min int =1 ,@max int=5
while @min<=@max
Begin

print REPLICATE('*', @min)

set @min=@min+1
End


-- PATTERN REVERSE


Declare @min int =1 ,@max int=5
while @min<=@max
Begin

print REPLICATE('*', @max)

set @max=@max-1
End




-- FIBONACCI

DECLARE @input int = 5, @prev int = 0, @curr int = 1, @temp int;

while @input > 0
Begin

print @prev
set @temp = @prev + @curr
set @prev = @curr
set @curr = @temp

set @input=@input-1
End



-- FACTORIAL

DECLARE @input int = 4, @temp int = 1;

while @input > 0
Begin

set @temp = @temp * @input

set @input=@input-1
End

print @temp

*/
-- ARMSTRONG NUMBER

DECLARE @input int = 153, @temp int = 1, @num int = 1, @result int = 0;
set @num = @input
while @num > 0
Begin

set @temp = @num % 10
set @num = @num / 10
set @temp = @temp * @temp * @temp
set @result = @result + @temp

End

if @input = @result
begin
print 'It is a Armstrong Number'
end
else
begin
print 'Not a Armstrong Number'
end
