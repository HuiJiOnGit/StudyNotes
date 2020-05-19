use TestDB

--1. ��ѯ" 01 "�γ̱�" 02 "�γ̳ɼ��ߵ�ѧ������Ϣ���γ̷���
select *
from (select SId ,score from sc where sc.CId='01')as t1 , (select SId ,score from sc where sc.CId='02') as t2
where t1.SId=t2.SId
and   t1.score>t2.score
--1.1 ��ѯͬʱ����" 01 "�γ̺�" 02 "�γ̵����
select *
from (select SId ,score from sc where sc.CId='01')as t1 , (select SId ,score from sc where sc.CId='02') as t2
where t1.SId=t2.SId
--1.2 ��ѯ����" 01 "�γ̵����ܲ�����" 02 "�γ̵����(������ʱ��ʾΪ null )
select *
from (select SId ,score from sc where sc.CId='01')as t1 left join  (select SId ,score from sc where sc.CId='02') as t2
on t1.SId=t2.SId
--1.3 ��ѯ������" 01 "�γ̵�����" 02 "�γ̵����
select *
from sc
where sc.SId not in (select SId from sc where sc.CId='01')
and  sc.CId='02'
--2. ��ѯƽ���ɼ����ڵ��� 60 �ֵ�ͬѧ��ѧ����ź�ѧ��������ƽ���ɼ�
select student.*,t1.avgscore
from student inner JOIN(
select sc.SId ,AVG(sc.score)as avgscore
from sc 
GROUP BY sc.SId
HAVING AVG(sc.score)>=60)as t1 on student.SId=t1.SId 
--3. ��ѯ�� SC ����ڳɼ���ѧ����Ϣ
select DISTINCT student.*
from student ,sc
where student.SId=sc.SId
--4. ��ѯ����ͬѧ��ѧ����š�ѧ��������ѡ�����������пγ̵��ܳɼ�(û�ɼ�����ʾΪ null )
select student.SId,student.Sname,t1.sumscore,t1.coursecount
from student ,(
select SC.SId,sum(sc.score)as sumscore ,count(sc.CId) as coursecount
from sc 
GROUP BY sc.SId) as t1
where student.SId =t1.SId
--4.1 ���гɼ���ѧ����Ϣ
select *
from student
where EXISTS(select * from sc where student.SId=sc.SId)
--5. ��ѯ�������ʦ������
select count(Tname) from Teacher where Tname like '��%'
--6. ��ѯѧ������������ʦ�ڿε�ͬѧ����Ϣ
select * from Student where sid in (select Sid from sc where CId in (select CId from Course where TId = (select TId from Teacher where Tname = '����')))
--7. ��ѯû��ѧȫ���пγ̵�ͬѧ����Ϣ
select student.*
from student 
where student.SId not in ( select sc.SId
from sc
group by sc.SId
having count(*)=(select count(CId) from course))
--8. ��ѯ������һ�ſ���ѧ��Ϊ" 01 "��ͬѧ��ѧ��ͬ��ͬѧ����Ϣ
select DISTINCT student.*
from  sc ,student
where sc.CId in (select CId from sc where sc.SId='01')
and   sc.SId=student.SId
--9. ��ѯ��" 01 "�ŵ�ͬѧѧϰ�Ŀγ� ��ȫ��ͬ������ͬѧ����Ϣ
select *
from student 
where student.SId not in (
select t1.SId
from 
(select student.SId,t.CId
from student ,(select sc.CId from sc where sc.SId='01') as t )as t1 
left join sc on t1.SId=sc.SId and t1.CId=sc.CId
where sc.CId is null )
and student.SId !='01'
--10. ��ѯûѧ��"����"��ʦ���ڵ���һ�ſγ̵�ѧ������

--11. ��ѯ���ż������ϲ�����γ̵�ͬѧ��ѧ�ţ���������ƽ���ɼ�

--12. ����" 01 "�γ̷���С�� 60���������������е�ѧ����Ϣ

--13. ��ƽ���ɼ��Ӹߵ�����ʾ����ѧ�������пγ̵ĳɼ��Լ�ƽ���ɼ�

--14. ��ѯ���Ƴɼ���߷֡���ͷֺ�ƽ���֣�

--��������ʽ��ʾ���γ� ID���γ� name����߷֣���ͷ֣�ƽ���֣������ʣ��е��ʣ������ʣ�������

--����Ϊ>=60���е�Ϊ��70-80������Ϊ��80-90������Ϊ��>=90

--Ҫ������γ̺ź�ѡ����������ѯ����������������У���������ͬ�����γ̺���������

--15. �����Ƴɼ��������򣬲���ʾ������ Score �ظ�ʱ�������ο�ȱ

--15.1 �����Ƴɼ��������򣬲���ʾ������ Score �ظ�ʱ�ϲ�����

--16. ��ѯѧ�����ܳɼ����������������ܷ��ظ�ʱ�������ο�ȱ

--16.1 ��ѯѧ�����ܳɼ����������������ܷ��ظ�ʱ���������ο�ȱ

--17. ͳ�Ƹ��Ƴɼ����������������γ̱�ţ��γ����ƣ�[100-85]��[85-70]��[70-60]��[60-0] ����ռ�ٷֱ�
select course.CId,course.Cname,t1.*
from course LEFT JOIN (
select sc.CId,CONCAT(sum(case when sc.score>=85 and sc.score<=100 then 1 else 0 end )/count(*)*100,'%') as '[85-100]',
CONCAT(sum(case when sc.score>=70 and sc.score<85 then 1 else 0 end )/count(*)*100,'%') as '[70-85)',
CONCAT(sum(case when sc.score>=60 and sc.score<70 then 1 else 0 end )/count(*)*100,'%') as '[60-70)',
CONCAT(sum(case when sc.score>=0 and sc.score<60 then 1 else 0 end )/count(*)*100,'%') as '[0-60)'
from sc
GROUP BY sc.CId) as t1 on course.CId=t1.CId
--18. ��ѯ���Ƴɼ�ǰ�����ļ�¼

--19. ��ѯÿ�ſγ̱�ѡ�޵�ѧ����

--20. ��ѯ��ֻѡ�����ſγ̵�ѧ��ѧ�ź�����

--21. ��ѯ������Ů������

--22. ��ѯ�����к��С��硹�ֵ�ѧ����Ϣ

--23. ��ѯͬ��ͬ��ѧ����������ͳ��ͬ������

--24. ��ѯ 1990 �������ѧ������

--25. ��ѯÿ�ſγ̵�ƽ���ɼ��������ƽ���ɼ��������У�ƽ���ɼ���ͬʱ�����γ̱����������

--26. ��ѯƽ���ɼ����ڵ��� 85 ������ѧ����ѧ�š�������ƽ���ɼ�

--27. ��ѯ�γ�����Ϊ����ѧ�����ҷ������� 60 ��ѧ�������ͷ���

--28. ��ѯ����ѧ���Ŀγ̼��������������ѧ��û�ɼ���ûѡ�ε������

--29. ��ѯ�κ�һ�ſγ̳ɼ��� 70 �����ϵ��������γ����ƺͷ���

--30. ��ѯ������Ŀγ�

--31. ��ѯ�γ̱��Ϊ 01 �ҿγ̳ɼ��� 80 �����ϵ�ѧ����ѧ�ź�����

--32. ��ÿ�ſγ̵�ѧ������

--33. �ɼ����ظ�����ѯѡ�ޡ���������ʦ���ڿγ̵�ѧ���У��ɼ���ߵ�ѧ����Ϣ����ɼ�

--34. �ɼ����ظ�������£���ѯѡ�ޡ���������ʦ���ڿγ̵�ѧ���У��ɼ���ߵ�ѧ����Ϣ����ɼ�

--35. ��ѯ��ͬ�γ̳ɼ���ͬ��ѧ����ѧ����š��γ̱�š�ѧ���ɼ�

--36. ��ѯÿ�Ź��ɼ���õ�ǰ����

--37. ͳ��ÿ�ſγ̵�ѧ��ѡ������������ 5 �˵Ŀγ̲�ͳ�ƣ���

--38. ��������ѡ�����ſγ̵�ѧ��ѧ��

--39. ��ѯѡ����ȫ���γ̵�ѧ����Ϣ

--40. ��ѯ��ѧ�������䣬ֻ���������

--41. ���ճ����������㣬��ǰ���� < �������µ������������һ

--42. ��ѯ���ܹ����յ�ѧ��

--43. ��ѯ���ܹ����յ�ѧ��

--44. ��ѯ���¹����յ�ѧ��

--45. ��ѯ���¹����յ�ѧ��

--PIVOTʹ��
SELECT pivotSource.Sname AS ����, pivotSource.����, pivotSource.��ѧ, pivotSource.Ӣ��
FROM(SELECT a.Sname, b.Cname, c.score
     FROM dbo.Student AS a, dbo.Course AS b, SC AS c
     WHERE a.SId=c.SId AND b.CId=c.CId) AS source
PIVOT(SUM(source.score)
      FOR source.Cname IN(����, ��ѧ, Ӣ��)) AS pivotSource;

SELECT *
FROM(SELECT a.Sname, b.Cname, c.score
     FROM dbo.Student AS a, dbo.Course AS b, SC AS c
     WHERE a.SId=c.SId AND b.CId=c.CId) AS m
PIVOT(SUM(m.score)
      FOR m.Sname IN(����, Ǯ��, ���, ����, ����, ֣��, ��÷)) AS n;

--casewhen
SELECT source.Sname AS ����, SUM(CASE WHEN source.Cname='����' THEN source.score END) ����, SUM(CASE WHEN source.Cname='��ѧ' THEN source.score END) ��ѧ, SUM(CASE WHEN source.Cname='Ӣ��' THEN source.score END) Ӣ��
FROM(SELECT a.Sname, b.Cname, c.score
     FROM dbo.Student AS a, dbo.Course AS b, SC AS c
     WHERE a.SId=c.SId AND b.CId=c.CId) AS source
GROUP BY source.Sname;
SELECT * FROM dbo.num;
SELECT years AS ��,
SUM(CASE WHEN mon = 1 THEN counts end)һ��,
SUM(CASE WHEN mon = 2 THEN counts end)����,
SUM(CASE WHEN mon = 3 THEN counts end)����,
SUM(CASE WHEN mon = 4 THEN counts end)����
FROM dbo.num
GROUP BY years;
SELECT * FROM dbo.num 
PIVOT 
(SUM(counts) FOR mon IN (1,2,3,4))
AS SOURCE

--��ҳ��ѯ--
--��ҳ������Ҫ����
SELECT TOP(5)* FROM sc ORDER BY score;
--ʹ�ã�top��Ҫ�����2ҳ�����ݣ��Ȳ����һҳ�����ݣ����ų���һҳ������
SELECT TOP(3)*
FROM dbo.Student
WHERE SId NOT IN(SELECT TOP(3 *(2-1))SId FROM dbo.Student)
ORDER BY SId
--ʹ��row_number()��ҳ
--��һ���߱��
SELECT fn=ROW_NUMBER() OVER (ORDER BY SId), * FROM dbo.Student;
go
--ÿҳ��ʾ3�����鿴�ڶ�ҳ
SELECT *
FROM(SELECT fn=ROW_NUMBER() OVER (ORDER BY SId), * FROM dbo.Student) AS t
WHERE t.fn BETWEEN (2-1)* 3+1 AND 3 * 2
go
DECLARE @a INT,@b INT
EXEC usp_bypage @recordcount=@a OUTPUT,@pagecount = @b OUTPUT
PRINT @a
PRINT @b
GO
--ʹ��Offset and Fetch��ҳ
SELECT * FROM dbo.Student;
SELECT *
FROM dbo.Student
ORDER BY SId OFFSET(3 *(1-1))ROW FETCH NEXT 3 ROWS ONLY;
